//$(document).ready(function () {

//    var albumForm = $("#AlbumCreateForm");
//    var updateDiv = $("#AlbumListDiv");

//    albumForm.submit(function (e) {
//        e.preventDefault();

//        $.ajax({
//            url: albumForm.attr('action'),
//            type: "POST",
//            data: albumForm.serialize(),
//            dataType: "html",
//            success: function (data) {
//                albumForm.trigger('reset');
//                updateDiv.html(data);
//            },
//            error: function () {
//                console.log("Internal error");
//            }
//        });


//    });


//});