$(document).ready(function () {
    var pictureForms = $(".PictureForm");

    pictureForms.submit(function (e) {
        var form = $(this);
        e.preventDefault();


        setTimeout(function() {

        }, 1000);


        $.ajax({
            method: "POST",
            url: form.attr('action'),
            data: new FormData(form[0]),
            dataType: "html",
            beforeSend:function() {
              
            },
            success: function (data) {

                form[0].reset();
                $("#PhotoContainer").html(data);
            },
            complete:function() {
                setTimeout(hideSpinner, 1000);
            },
            processData: false,
            contentType: false
        });
    });
})

//function showSpinner() {
//    $("input:submit").prop('disabled', true);
//    $('*').css("cursor", "progress");
//    $(".spinner").removeClass("hidden");
//    $(".spinner").css("top", "10%");
//}
//function hideSpinner() {
//    $('*').css("cursor", "default");
//    $(".spinner").addClass("hidden");
//    $(".spinner").css("top", "-10%");
//    $("input:submit").prop('disabled', false);
//}


