         function uploadPopup(value, row, index) {
             var str = '<a href="#" name="opera" class="easyui-linkbutton" onclick="showUploadImgDialog(\'' + value + '\')"></a>';
             //var str = "<a href='#' name='opera' class='easyui-linkbutton' onclick='showUploadImgDialog('" + value + "');'></a>";
             //var str = "<input type='button' value='click'>" ;
             return str;
         }

         function showUploadImgDialog(photo) {
             if (photo) {
                 $('#dlgUploadImg').dialog('open').dialog('center').dialog('setTitle', '上传图片');
                 $('#fmUploadImg').form('load', { 'photo': photo});
             }


         }

         function uploadImg2() {
             var file = document.getElementById('filebox_file_id_1').files[0];
             if (file == null) {
                 alert("上传文件出现错误！");
                 return;
             }
             var formData = new FormData();
             //var filePath = 'FoodMaterial' + '/' + $('#description').val() + '.jpg';
             var filePath =  $('#photo').val() ;
             formData.append('photoFilePath', filePath);
             formData.append('imgfile', file);
             $.ajax({
                 type: "POST",
                 url: '/Image/Upload',
                 contentType: false,
                 processData: false,
                 data: formData,
                 success: function (res) {
                     if (res.success) {
                         abp.notify.success('上传文件成功：', res.result);

                         $('#dlgUploadImg').dialog('close');
                         $('#listGrid').datagrid('reload');
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
