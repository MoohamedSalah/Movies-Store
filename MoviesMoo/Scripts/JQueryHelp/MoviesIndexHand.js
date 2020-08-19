$(document).ready(function () {
    var moviesTable = $('#tblMovies').DataTable();

    $("#tblMovies").on("click", ".js-delete", function () {
        var button = $(this);
        var movieId = button.attr("data-table-id");

        // button.closest('#moviesBody').find('.movieId');
        bootbox.confirm("Are ou sure you want Delete This ?!", function (result) {
            if (result) {
                $.ajax({
                    url: "api/Movies/" + movieId,
                    method: "DELETE",
                    success: function () {
                        moviesTable.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
    });

    //list of coments
    //add comment with ajax ( page not reload)
    //add comment => 1) comment added in server side - Done: add comment client side (using jquery)
    //delete this comment before reload this page 

});