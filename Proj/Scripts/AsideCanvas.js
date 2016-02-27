var X = 0;
var dataResault;
var len;

function init() {
    var canvas = document.getElementById("canvas");
    if (canvas.getContext) {
        var ctx = canvas.getContext("2d");

        // Set the banner text attributes
        ctx.fillStyle = "red";
        ctx.shadowOffsetX = 4;
        ctx.shadowOffsetY = 4;
        ctx.shadowBlur = 3;
        ctx.shadowColor = "grey";
        ctx.font = "14px verdana";
        

        
        // Call the moveBanner() function repeatedly every 40 microseconds
        setInterval(function () { moveBanner() }, 40);
    }
}
$(document).ready(function()
    {
        $.ajax({
        type: "GET",
        url: "/Banner",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        
       // data: JSON.stringify(text),
           
        success: function (data) {
            dataResault = data;
            init();
        },
        error: function () { alert("error post"); }
    });

    }
)



function moveBanner() {
    var canvas = document.getElementById("canvas");
    if (canvas.getContext) {
        var ctx = canvas.getContext("2d");

        // Clear the screen
        ctx.clearRect(0, 0, 100, 400);
        var size = dataResault[0];
        for (var i = 1; i < size; i=i+2) {
            ctx.fillText(dataResault[i], 10, X+i*20);
            
        }
            
        X += 1;

        // If the banner has reached the left end of the screen, resent the x-coordinate
        if (X >400)
            X = 0
    }
}

