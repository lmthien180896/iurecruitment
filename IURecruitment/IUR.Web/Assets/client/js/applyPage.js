var applyPage = {
    init: function () {
        applyPage.registerEvents();
    },
    registerEvents: function () {
        $('#addEduBG').off('click').on('click', function (e) {
            e.preventDefault();
            var tbody = $('#CO_rows');
            tbody.append('<tr><td><select class="form-control" name="EducationBackground.Level"><option>PhD</option><option>Master</option><option>Bachelor</option><option>Diploma</option></select></td ><td><input type="text" class="form-control" name="EducationBackground.School" /></td><td><input type="text" class="form-control" name="EducationBackground.Country" /></td><td><input type="text" class="form-control" name="EduBackGround.Major" /></td><td><input type="date" class="form-control" name="EducationBackground.GraduatedDate" /></td></tr>');
        });

        $('#addLanguage').off('click').on('click', function (e) {
            e.preventDefault();
            var tbody = $('#language_rows');
            tbody.append('<tr><td><input type="text" name="Language.Certificate" class="form-control" placeholder="IELTS, TOELF, ..."/></td ><td><input type="text" class="form-control" name="Language.Grade" /></td></tr>');
        });

        $('#addCompskill').off('click').on('click', function (e) {
            e.preventDefault();
            var tbody = $('#compskill_rows');
            tbody.append('<tr><td><input type="text" name="ComputerSkill.Software" class="form-control" placeholder="Microsoft Office, Photoshop, SPSS softwares, ..." /></td ><td><select class="form-control" name="ComputerSkill.Level"><option>Please Select</option><option>Basic</option><option>Intermediate</option><option>Advanced</option></select ></td></tr>');
        });

        $('#addOtherskill').off('click').on('click', function (e) {
            e.preventDefault();
            var tbody = $('#otherskill_rows');
            tbody.append('<tr><td><input type="text" name="OtherSkill.Skill" class="form-control" placeholder="Soft skills, ..." /></td ><td><input type="text" name="OtherSkill.Reference" class="form-control" placeholder="" /></td></tr>');
        });

        $('#addEmHis').off('click').on('click', function (e) {
            e.preventDefault();
            var tbody = $('#emhis_rows');
            tbody.append('<tr><td><input type ="date" class="form-control" name="Experience.FromDate" /></td><td><input type="date" class="form-control" name="Experience.ToDate"/></td><td><input type="text" class="form-control" name="Experience.Company" /></td><td><input type="text" class="form-control" name="Experience.Position" /></td><td><textarea class="form-control" name="Experience.Description"></textarea></td><td><textarea class="form-control" name="Experience.Reason"></textarea></td></tr>');
        });

        $('.txtimageFile').on('change', function () {
            var file = $(this).val();
            var ext = file.split(".");
            ext = ext[ext.length - 1].toLowerCase();
            if (ext != "") {
                var arrayExtensions = ["jpg", "jpeg", "png", "gif"];

                if (arrayExtensions.lastIndexOf(ext) == -1) {
                    bootbox.alert("Please input a valid file.");
                    $(".txtimageFile").val("");
                }
            }
        });

        $('.txtresumeFile').on('change', function () {
            var file = $(this).val();
            var ext = file.split(".");
            ext = ext[ext.length - 1].toLowerCase();
            if (ext != "") {
                var arrayExtensions = ["pdf"];

                if (arrayExtensions.lastIndexOf(ext) == -1) {
                    bootbox.alert("Please input a valid file.");
                    $(".txtresumeFile").val("");
                }
            }
        });

        $('#btnSubmit').off('click').on('click', function () {
            var validated = true;

            var length = $('#txtFullname').val().length;
            if (length < 1 || length > 32) {
                $('#txtFullname').addClass("invalidate-input");
                $('#warning-fullname').text("Your name must have 1-32 characters.");
                validated = false;
            }

            if ($('#txtDOB').val() == "") {
                $('#txtDOB').addClass("invalidate-input");
                $('#warning-dob').text("Please enter a valid date.");
                validated = false;
            }

            if ($('#txtPOB').val() == "") {
                $('#txtPOB').addClass("invalidate-input");
                $('#warning-pob').text("Please enter place of birth.");
                validated = false;
            }

            if ($('#txtNationality').val() == "") {
                $('#txtNationality').addClass("invalidate-input");
                $('#warning-nationality').text("Please enter your nationality.");
                validated = false;
            }    

            length = $('#txtCAddress').val().length;
            if (length < 3 || length > 128) {
                $('#txtNationality').addClass("invalidate-input");
                $('#warning-caddress').text("Your address must have 3-128 characters.");
                validated = false;
            }    
            length = $('#txtPAddress').val().length;
            if (length < 3 || length > 128) {
                $('#txtPAddress').addClass("invalidate-input");
                $('#warning-paddress').text("Your address must have 3-128 characters.");
                validated = false;
            }   

            var phone = $('#txtPhone').val();
            if (phone == "") {
                $('#txtPhone').addClass("invalidate-input");
                $('#warning-phone').text("Please enter a valid phone number.");
                validated = false;
            }
            //var phonefilter = /\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})/;
            //if (!phonefilter.test(phone) || phone.length < 12) {
            //    $('#txtPhone').addClass("invalidate-input");
            //    $('#warning-phone').text("Please enter a valid phone number.");
            //    validated = false;
            //} 

            var email = $('#txtEmail').val();
            var emailfilter = /^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;
            if (!emailfilter.test(email)) {
                $('#txtEmail').addClass("invalidate-input");
                $('#warning-email').text("Please enter a valid email.");
                validated = false;
            } 
            
            var idnum = $('#txtIDNum').val();
            var idnumfilter = /[^0-9]/;
            if (!idnumfilter.test(idnum) && idnum.length < 9) {
                $('#txtIDNum').addClass("invalidate-input");
                $('#warning-idnum').text("Please enter a valid ID number.");
                validated = false;
            } 

            if ($('#txtIssuedOn').val() == "") {
                $('#txtIssuedOn').addClass("invalidate-input");
                $('#warning-issuedOn').text("Please enter a valid date.");
                validated = false;
            }

            if ($('#txtIssuedPlace').val() == "") {
                $('#txtIssuedPlace').addClass("invalidate-input");
                $('#warning-issuedPlace').text("Please enter issued place.");
                validated = false;
            }

            if ($('#sltAvailable').val() == "Please Select") {
                $('#sltAvailable').addClass("invalidate-input");
                validated = false;
            }
                        
            if ($('#sltInformed').val() == "Please Select") {
                $('#sltInformed').addClass("invalidate-input");
                validated = false;
            }

            if ($('#sltAppliedIU').val() == "Please Select") {
                $('#sltAppliedIU').addClass("invalidate-input");
                validated = false;
            }

            if ($('.txtresumeFile').val() == "") {
                $('.txtresumeFile').addClass("invalidate-input");
                $('#warning-resume').text("Please input your resume.");
                validated = false;
            }

            if (validated) {
                $('#myForm').submit();
            }
            else {
                $('#txtFullname').focus();
            }
        });
    }

};

applyPage.init();