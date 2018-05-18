var _appService; //ABP后台服务代理
var _entityName;     //实体名

var _currentEntity;

function _S( action ){
    return action + _entityName;
}

function reload() {
    $('#listGrid').datagrid('reload');
}


function create() {
    _currentEntity = null;

    $('#dlg').dialog('open').dialog('center').dialog('setTitle', _S('添加'));
    $('#fm').form('clear');
}

function edit() {
    var row = $('#listGrid').datagrid('getSelected');
    if (row) {
        _currentEntity = row;
        $('#dlg').dialog('open').dialog('center').dialog('setTitle', _S('编辑'));
        $('#fm').form('load', row);
    }
}

function save() {
    var _$form = $('form[name=editForm]');

    if (!_$form.valid()) {
        return;
    }

    var entity = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js

    if ( _currentEntity ) {
        entity = $.extend(true, _currentEntity, entity);
    }

    abp.ui.setBusy(_$form);

    var saveAction = entity.id == 0 ? _appService.create : _appService.update;

    saveAction(entity).done(function () {
        $('#dlg').dialog('close');      // close the dialog
        reload();  // reload the user data
    }).always(function () {
        abp.ui.clearBusy(_$form);
    });
}

function doDelete(row) {
    abp.ui.setBusy($('#listGrid'));
    _appService.delete(row).done(function () {
        reload();
    }).always(function () {
        abp.ui.clearBusy($('#listGrid'));
    });
}

function del() {
    var row = $('#listGrid').datagrid('getSelected');

    if (row) {
        abp.message.confirm(
            _S('删除'),
            '请确认?',
            function (isConfirmed) {
                if (isConfirmed) {
                    doDelete(row);
                }
            }
        );
    }
}

function filterData(data) {
    if (data.result) {
        return data.result;
    }
    else
        if (data.items) {
            return data.items;
        }
        else {
            return data;
        }
}

function imgFormater(imgFile) {
    return "<img style='width:24px;height:24px;' border='1' src='" + imgFile + "'/>";
}

function initForm() {
    $('.easyui-datebox').datebox({
        formatter: function (date) {
            if (date) {
                return new Date(date).Format("yyyy-MM-dd");
            }
            return date;
        },
        parser: function (s) {
            var t = Date.parse(s);
            if (!isNaN(t)) {
                return new Date(t);
            } else {
                return new Date();
            }
        }
    });
}

function initListDataGrid( options ) {
    $('#listGrid').datagrid(
     $.extend(true,{
        singleSelect: true,
        loadFilter: function (data) {
            console.log(data);
            if (data.result) {
                if (data.result.items) {
                    var pageData = {};
                    pageData.total = data.result.totalCount;
                    pageData.rows = data.result.items;
                    return pageData;
                }

            }
            else
                if (data.items) {
                    var pageData = {};
                    pageData.total = data.totalCount;
                    pageData.rows = data.items;
                    return pageData;
                } else {
                    return data;
                }
        },
        pagination: true,
        
        loader: function (param, success, error) {
            console.log(param);
            //var _appService = abp.services.app.foodMaterial;
            var data = _appService.getAll(param)
                .done(function (data) {
                    //listGrid.datagrid("loadData", data);
                    success(data);
                });
        },

        toolbar: [
            {
                iconCls: 'icon-add',
                text: '添加',
                handler: function () {
                    create();
                }
            },
            {
                iconCls: 'icon-edit',
                text: '编辑',
                handler: function () {
                    edit();
                }
            },
            {
                iconCls: 'icon-remove',
                text: '删除',
                handler: function () {
                    del();
                }
            },
            '-',
            {
                iconCls: 'icon-reload',
                text: '刷新',
                handler: function () {
                    reload();
                }
            }
        ],
    }, options));
}

function initCombobox( inputElementName, lookupService ) {
    $(inputElementName).combobox({
        valueField: 'id',
        textField: 'text',
        editable: false,
        loadFilter: filterData,
        loader: function (param, success, error) {
            //console.log(param);
            lookupService.getLookUp()
                .done(function (data) {
                    success(data);
                });
        },

    });
}

function xinitCombobox() {
    var fmcComboboxs = [$('#foodMaterialCategory'), $("[name$='foodMaterialCategoryId'")];
    $.each(fmcComboboxs, function () {
        $(this).combobox({
            valueField: 'id',
            textField: 'name',
            editable: false,
            loadFilter: filterData,
            onBeforeLoad: function (param) {
                console.log(param);
            },
            loader: function (param, success, error) {
                console.log(param);
                var _appService = abp.services.app.foodMaterialCategory;
                var data = _appService.getAll(param)
                    .done(function (data) {
                        success(data);
                    });
            },

        })
    });

}





