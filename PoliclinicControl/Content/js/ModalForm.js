$('.call_dialog_edit').click(function () {
    var click_obj = $(this);
    var modal_name = 'dialog_edit';
    var action_object = click_obj.data('action-object');
    
    if (action_object != undefined) {
        $.post(action_object, function (data) {
            obj = data;
            $('#' + modal_name + ' .form-control').each(function () {
                
                var name = $(this).attr('name');
                console.log(data, name);
                $(this).val(data[name]);
            });
        });
    }
    else {
        $('#' + modal_name + ' .form-control').each(function () {
            $(this).val('');
        });
    }
   


    $('#' + modal_name).modal('show');
});
