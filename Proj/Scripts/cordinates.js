function getCordinates() {
    var dataResault3;
    var addr = document.getElementById("Address").value;
    console.log(addr);
    console.log("ajax coordinates statrs");
    $.ajax({
        type: "GET",
        url: ("/Address?location=" + addr),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data3) {
            dataResault3 = data3;
            console.log("initating Address Converter");
            
            document.getElementById("latLocation").value = dataResault3[0].toString();
            document.getElementById("longLocation").value = dataResault3[1].toString();
        },
        error: function () { alert("error post"); }
    });
}






