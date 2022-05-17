$(document).ready(function () {
    "use strict";
    const second = 1000,
        minute = second * 60,
        hour = minute * 60,
        day = hour * 24;
    let countDown = new Date("2022/05/07 15:30:00").getTime(),
        x = setInterval(function () {
            let now = new Date().getTime(),
                distance = countDown - now;
            (document.getElementById("days").innerText = Math.floor(
                distance / day
            )),
                (document.getElementById("hours").innerText = Math.floor(
                    (distance % day) / hour
                )),
                (document.getElementById("minutes").innerText = Math.floor(
                    (distance % hour) / minute
                )),
                (document.getElementById("seconds").innerText = Math.floor(
                    (distance % minute) / second
                ));
        }, second);
});