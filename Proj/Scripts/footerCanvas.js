var dataResault2;

$(document).ready(function () {
    
    console.log("Footer Ready")
    console.log("ajax statrs");
    $.ajax({
        type: "GET",
        url: "/Weather",
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        //data: JSON.stringify(text),

        success: function (data2) {
            dataResault2 = data2;
            console.log("initating Weather Canvas");
            init2();
        },
        error: function () { alert("error post"); }
    });
});
var x2 = 40;
var y2 = 10;
function orgenize() {
    var canvas = document.getElementById("myCanvas2");
    if (canvas.getContext) {
        var ctx = canvas.getContext("2d");

        // Clear the screen
        ctx.clearRect(0, 0, 300, 100);
        ctx.fillText(dataResault2[0] + " " + "The" + " " + dataResault2[1], x2, y2);
        ctx.fillText("And the max temperature will be " + dataResault2[2] +" c ", x2, y2 + 15);
        var picFlg = parseInt(dataResault2[2]);
        if(picFlg>16)
        {
            console.log("sunny chosen");
            var wimg = $("#sunny").get(0);
            ctx.drawImage(wimg, 80, 30);
        } else {
            console.log("rain chosen");
            var wimg = $("#rain").get(0);
            ctx.drawImage(wimg, 80, 30);
        }
    }
}


function init2() {
    var canvas = document.getElementById("myCanvas2");
    if (canvas.getContext) {
        var ctx = canvas.getContext("2d");

        // Set the banner text attributes
        ctx.fillStyle = "grey";
        ctx.shadowOffsetX = 4;
        ctx.shadowOffsetY = 4;
        ctx.shadowBlur = 3;
        ctx.font = "12px verdana";
        orgenize();
    }
}





