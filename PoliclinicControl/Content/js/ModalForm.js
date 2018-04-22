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

if ($('#send_med_attach').length > 0) {
    $('#send_med_attach').hide();
    $('#js_find_client').click(function () {
        var val = $("#js_find_client_val").val();
        console.log(val);
        $.post("/MedAttach/GetAjaxClients", { find: val }).done(function (data) {
            $('#ClientId').empty();
            if (data.length == 0) {
                $('#send_med_attach').hide('slow');
                return false;
            }

            $.each(data, function (index, value) {
                $('#ClientId').append("<option value='" + value.Id + "'>" + value.FName + " " + value.PName + " " + value.LName + " </option>");

            });

            $('#send_med_attach').show('slow');
        });
    });
}





