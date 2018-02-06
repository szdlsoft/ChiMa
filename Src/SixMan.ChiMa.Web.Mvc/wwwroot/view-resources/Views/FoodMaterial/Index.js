
var _appService ;

$(function () {
    _appService = abp.services.app.foodMaterial;

    //initDateFormat();
    initQuery();
    initListDataGrid();
    //initForm();

    //reloadData();

});

function initDateFormat() {
    // 对Date的扩展，将 Date 转化为指定格式的String
    // 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符，
    // 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字)
    // 例子：
    // (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423
    // (new Date()).Format("yyyy-M-d h:m:s.S")   ==> 2006-7-2 8:9:4.18
    Date.prototype.Format = function (fmt) { //author: meizz
        var o = {
            "M+": this.getMonth() + 1, //月份
            "d+": this.getDate(), //日
            "h+": this.getHours(), //小时
            "m+": this.getMinutes(), //分
            "s+": this.getSeconds(), //秒
            "q+": Math.floor((this.getMonth() + 3) / 3), //季度
            "S": this.getMilliseconds() //毫秒
        };
        if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
        for (var k in o)
            if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
        return fmt;
    }
}

function initQuery() {
    var fmcComboboxs = [$('#foodMaterialCategory'), $("[name$='foodMaterialCategoryId'")];
    $.each(fmcComboboxs, (function(){
       $(this).combobox({
        //url: '/api/services/app/testAction/GetTypeKeys',
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
    }));

    $('#foodMaterialName').textbox({
        prompt:'食材名称',
    });


    /*

    $('#tooling').combobox({
        valueField: 'text',
        textField: 'text',
        editable: false,
        loadFilter: filterData,
        onSelect: function (rec) {
            $('#cavity').combobox('reload', '/api/services/app/testAction/GetCavityies?keyType=' + rec.id + '&tooling=' + rec.text);
        }
    });
    $('#cavity').combobox({
        valueField: 'text',
        textField: 'text',
        editable: true,
        loadFilter: filterData,
        multiple: true,
    });
    $('#defect').combobox({
        valueField: 'text',
        textField: 'text',
        editable: true,
        loadFilter: filterData,
        multiple: true,
    });

    $('#driQuery').combobox({
        url: '/api/services/app/testAction/GetDris',
        valueField: 'text',
        textField: 'text',
        editable: false,
        loadFilter: filterData,
    });
    */

    $('#query').click(function () {
        $('#listGrid').datagrid('reload');
    });


}

function filterData(data) {
    if (data.result) {
        return data.result;
    } 
    else
    if( data.items)
    {
        return data.items;
    }
    else
    {
        return data;
    }
}

function initListDataGrid() {
    $('#listGrid').datagrid({
        //url: '/api/services/app/foodMaterial/GetAll',
        singleSelect: true,
        columns: [[
            { field: 'id', title: 'id', width: 50, align: 'right' },
            { field: 'description', title: '名称', width: 100, align: 'right' },
            { field: 'foodMaterialCategoryName', title: '类别', width: 100, align: 'right' },
            { field: 'foodMaterialCategoryIndexNo', title: '类别索引号', width: 100, align: 'right' },
        ]],
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
        onBeforeLoad: function (param) {

            param.skipCount = (param.page - 1) * param.rows;
            param.maxResultCount = param.rows;

            param.foodMaterialCategoryId = $('#foodMaterialCategory').val();
            param.name = $('#foodMaterialName').val();
            //param.cavity = $('#cavity').val();
            //param.defect = $('#defect').val();
            //param.dateFrom = $('#dateFrom').val();
            //param.dateTo = $('#dateTo').val();

            //param.dri = $('#driQuery').val();
            //param.status = $('#statusQuery').val();

            //var temp = {};
            //temp.skipCount = param.skipCount;
            //temp.maxResultCount = param.maxResultCount;

            //param = temp;
            //console.log(param);

        },
        loader: function (param, success, error) {
            console.log(param);
            //var _appService = abp.services.app.foodMaterial;
            var data = _appService.getAll(param)
                .done(function (data) {
                    //listGrid.datagrid("loadData", data);
                    success(data);
                });
        },

        //onClickRow: function (index, row) {
        //    if (row) {
        //        $('#dlg').dialog('open').dialog('setTitle', 'Edit Action');
        //        $('#fm').form('load', row);
        //        url = '/api/services/app/testAction/Update?id=' + row.id;
        //    }
        //},
        toolbar: [
            {
                iconCls: 'icon-add',
                text:'添加',
                handler: function(){
                    create();
                }
            },            
            {
                iconCls: 'icon-edit',
                text:'编辑',
                handler: function(){
                    edit();
                }
            },
            {
                iconCls: 'icon-remove',
                text:'删除',
                handler: function(){
                    alert('remove')
                }
            },
            '-',
            {
                iconCls: 'icon-reload',
                text:'刷新',
                handler: function(){
                    alert('refresh')
                }
            }
        ],
    });
}

function create(){
    $('#dlg').dialog('open').dialog('center').dialog('setTitle','添加食材');
    $('#fm').form('clear');
}

function edit(){
    var row = $('#listGrid').datagrid('getSelected');
    if (row){
         $('#dlg').dialog('open').dialog('center').dialog('setTitle','编辑食材');
         $('#fm').form('load',row);
    }
}

function save() {
    var _$form = $('form[name=editForm]');

    if (!_$form.valid()) {
            return;
        }

    var entity = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
    abp.ui.setBusy(_$form);
    _appService.creatOrUpdate(entity).done(function () {
        $('#dlg').dialog('close');      // close the dialog
        $('#listGrid').datagrid('reload');  // reload the user data
    }).always(function () {
        abp.ui.clearBusy(_$form);
    });

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

function uploadImg() {
    var formData = new FormData();
    formData.append('id', operate.EntityModel.id());
    formData.append('imgfile', $("#imgfile")[0].files[0]);
    $.ajax({
        type: "POST",
        url: '/' + domainCrud.urlPath + '/UploadImg',
        contentType: false,
        processData: false,
        data: formData,
        success: function (res) {
            if (res.success) {
                operate.EntityModel.photo(res.result);
                abp.notify.success('上传文件成功：', res.result);
            }
            else {
                abp.message.error('上传文件出现错误:', res.error.message);
            }
        },
        error: function () {
            alert("上传文件出现错误！");
        }
    });
}