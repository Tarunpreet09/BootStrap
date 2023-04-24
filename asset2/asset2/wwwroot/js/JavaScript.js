function save() {
    var json = {};
    json.face = $('#facebook').val();
    json.twit = $('#twitter').val();
    json.insta = $('#instagram').val();
    json.link = $('#linkedin').val();
    json.pint = $('#pinterest').val();
    json.you = $('#youtube').val();

    $.ajax({
        type: "GET",
        url: "/Home/Save1",
        data: json,
        //datatype: "JSON",
        //success: function (res) {
        //    alert(JSON.stringify(res));
        //}
        })
   
}