Ext.define('Ext.gridPanelClass',
{
    extend: 'Ext.grid.Panel',

    initComponent: function (config) {
        this.callParent(arguments);
    },


    getId: function () {
        var me = this;
        return me.config.id;
    },
    constructor: function (config) {

        var me = this;

        //Load Tooltip
        Ext.QuickTips.init();

        //Clean PlaceHolder
        if (config.renderTo != null)
            Ext.getDom(config.renderTo).innerHTML = '';

        //set Generator
        config.generator = lib.helper.idGenerator("Model");

        //Define Model
        Ext.define(config.generator, { extend: 'Ext.data.Model', fields: config.fields });

        //Define Store
        config.store = Ext.create('Ext.data.Store',
        {
            model: config.generator,
            autoDestroy: true,
            autoSync: false,
            autoLoad: (config.autoLoad == null) ? true : config.autoLoad,
            remoteSort: true,
            sorters: config.sorters,
            pageSize: config.pageSize,
            groupField: "fname",

            proxy:
                {
                    type: 'rest',
                    url: config.url,
                    extraParams: config.extraParams,
                    reader:
                    {
                        type: 'json',
                        root: 'root',
                        totalProperty: 'totalCount'
                    }
                }
        });

        //Properties
        config.bodyBorder = false;
        config.stateful = true;
        config.frame = false;
        config.loadMask = true;
        config.remoteSort = true;
        config.columnLines = ((config.columnLines == null) ? false : config.columnLines);


        if (config.topItems == null) config.topItems = [];
        if (config.bottomLItems == null) config.bottomLItems = [];
        if (config.bottomRItems == null) config.bottomRItems = [];
        if (config.leftItems == null) config.leftItems = [];
        if (config.rightItems == null) config.rightItems = [];


        config.dockedItems =
            [
                {
                    dock: 'top',
                    xtype: 'toolbar',
                    items: config.topItems
                }
                , {
                    dock: 'bottom',
                    xtype: 'toolbar',
                    items: config.bottomLItems.concat(['->'], config.bottomRItems)
                }
                , {
                    dock: 'left',
                    xtype: 'toolbar',
                    items: config.leftItems
                }
                , {
                    dock: 'right',
                    xtype: 'toolbar',
                    items: config.rightItems
                }
            ];


        //*******************************************************************************
        //*****************************plugins*******************************************
        //*******************************************************************************

        config.plugins = [];

        //paginator
        if (config.bottomPaginator) {

            var tempDockedItems = config.dockedItems[1];
            config.dockedItems.splice(1, 1);

            config.dockedItems.push(
            {
                dock: 'bottom',
                xtype: 'pagingtoolbar',
                store: config.store,
                displayInfo: true,
                displayMsg: 'Results {0} - {1} of {2}',
                emptyMsg: 'No topics to display',

                plugins:
                [
                    Ext.create('Ext.ux.SlidingPager', {}),
                    Ext.create('Ext.ux.ProgressBarPager', {})
                ]
            });

            config.dockedItems.push(tempDockedItems);

        } //paginator
        //Search
        if (config.searchBar) {
            config.dockedItems[0].items.push('->');
            config.dockedItems[0].items.push(
            {
                width: 200,
                fieldLabel: '',
                labelWidth: 50,
                xtype: 'searchfield',
                store: config.store,
                emptyText: 'Search'
            });
        }

        if (config.rowNumber) {
            //Row Numberer
            var oldColumnsOrder = config.columns;

            config.columns = [];
            config.columns.push(Ext.create('Ext.grid.RowNumberer'));
            for (var item in oldColumnsOrder)
                config.columns.push(oldColumnsOrder[item]);

        }

        config.features = [];
        if (config.groupping) {
            config.features.push(
            {
                id: "groupingID",
                ftype: 'grouping',
                groupHeaderTpl: '{name}', //{rows.length}
                startCollapsed: true
            });

        }
        if (config.grouppingSummary) {
            config.features.push(
            {
                id: "groupingsummaryID",
                ftype: 'groupingsummary',
                groupHeaderTpl: '{name}', //{rows.length}
                startCollapsed: false
            });
        }



        //Enable RowEditing
        if (config.rowEditable===true) {
            me.rowEditing = Ext.create('Ext.grid.plugin.RowEditing', { clicksToMoveEditor: 1, autoCancel: true });
            config.plugins.push(me.rowEditing);
        }

        //Enable cellEditing
        if (config.cellEditable===true) {
            //dont combine w/ checkbox model
            me.cellEditing = Ext.create('Ext.grid.plugin.CellEditing', { clicksToEdit: 1 });
            config.plugins.push(me.cellEditing);
			
			config.selModel= 
			{
				selType: 'cellmodel'
			}
        }
        
        me.config = config;
        this.callParent(arguments);
    },

    afterRender: function () {
        var me = this;

        this.callParent(arguments);
    }
});     
