var control = {
    init: function () {       
        control.registerEvent();
    },

    registerEvent: function () {               
        $('#txtNewPassword').off('keyup').on('keyup', function () {
            control.comparePasswords();
        });
        $('#txtConfirmedPassword').off('keyup').on('keyup', function () {
            control.comparePasswords();
        });

        $('#btnChangePassword').off('click').on('click', function () {
            control.submitForm();
        });

    },

    submitForm: function () {
        var id = $('#txtID').val();
        var currentPassword = $('#txtCurrentPassword').val();
        var newPassword = $('#txtNewPassword').val();
        var confirmedPassword = $('#txtConfirmedPassword').val();      
        if (currentPassword == "" || newPassword == "" || confirmedPassword == "") {
            toastr.warning("Make sure to all fields");
        }
        else {
            var data = {
                ID: id,
                CurrentPassword: currentPassword,
                NewPassword: newPassword,
                ConfirmedPassword: confirmedPassword
            };
            $.ajax({
                url: '/Admin/User/ChangePassword',
                type: 'POST',
                dataType: 'json',
                data: { model: JSON.stringify(data) },
                success: function (response) {
                    if (response.status) {
                        toastr.success(response.message);                        
                    }
                    else {
                        toastr.error(response.message);
                    }
                }
            });
        }
    },      

    comparePasswords: function () {
        var newPassword = $('#txtNewPassword').val();
        var confirmedPassword = $('#txtConfirmedPassword').val();
        if (newPassword != confirmedPassword) {
            $('#txtNewPassword').addClass('invalidate-input');
            $('#txtConfirmedPassword').addClass('invalidate-input');
            $('#warning-password').show();
            $('#matching-password').hide();
            $('#btnChangePassword').prop('disabled', true);         
        }
        else {
            $('#txtNewPassword').removeClass('invalidate-input');
            $('#txtConfirmedPassword').removeClass('invalidate-input');
            $('#warning-password').hide();
            $('#matching-password').show();
            $('#btnChangePassword').prop('disabled', false);     
        }
    }    
};

control.init();