var ExtStoreClass;
(function ($) {

		ExtStoreClass=cls.define(
    	{ 
		
			initialize: function (config) {
                var me = this;

                me.config = config;
                
            },

            init: function () {
                var me = this;

                me.config.generator = lib.helper.idGenerator('Model');

                Ext.define(me.config.generator, { extend: 'Ext.data.Model', fields: me.config.fields });
                var store = Ext.create('Ext.data.Store',
                {
                    model: me.config.generator,
                    autoDestroy: true,
                    autoLoad: true,
                    autoSync: false,

                    proxy: {
                        type: 'rest',
                        url: me.config.url,
                        extraParams: me.config.extraParams,
                        reader:
                        {
                            type: 'json',
                            root: 'root'
                        }
                    }
                });
                return store;
            }
        
		});



} (jQuery));
