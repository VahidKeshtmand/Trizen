$(".visits-chart").sparkline([0, 0, 1e3, 1250, 3e3, 2500, 2100, 2500, 2450, 4e3, 2200,
    2300, 2e3, 2100, 1700, 2020, 2050, 1800, 1850, 1100, 1400, 1750, 1500]
    , {
        type: "line",
        width: "90px",
        height: "25px",
        lineColor: "#287dfa",
        fillColor: "#ebf5f9",
        spotColor: "#2273e5",
        minSpotColor: "#2273e5",
        maxSpotColor: "#2273e5",
        highlightSpotColor: "#808996",
        highlightLineColor: "#808996",
        spotRadius: 0,
        chartRangeMin: 5,
        chartRangeMax: 10,
        chartRangeMinX: 5,
        chartRangeMaxX: 5,
        normalRangeMin: 5,
        normalRangeMax: 5,
        normalRangeColor: "#ebf5f9",
        drawNormalOnTop: !0
    }),
    $(".previews-chart").sparkline([1, 21, 17, 20, 50, 18, 16, 1, 5, 20,
        14, 12, 11, 25, 7, 3, 35, 23, 16, 12, 7, 16, 25],
        {
            type: "line",
            width: "90px",
            height: "25px",
            lineColor: "#287dfa",
            fillColor: "#ebf5f9",
            spotColor: "#2273e5",
            minSpotColor: "#2273e5",
            maxSpotColor: "#2273e5",
            highlightSpotColor: "#808996",
            highlightLineColor: "#808996",
            spotRadius: 0,
            chartRangeMin: 5,
            chartRangeMax: 10,
            chartRangeMinX: 5,
            chartRangeMaxX: 5,
            normalRangeMin: 5,
            normalRangeMax: 5,
            normalRangeColor: "#ebf5f9",
            drawNormalOnTop: !0
        }),
    $(".visits-chart-2").sparkline([1, 3, 5, 10, 8, 9, 10, 8, 7, 8, 9, 7, 8,
        7, 9, 8, 7, 8, 7, 8, 9, 10, 8, 9, 8, 10, 6],
        {
            type: "line",
            width: "90px",
            height: "15px",
            lineColor: "#287dfa",
            fillColor: "#ebf5f9",
            spotColor: "#2273e5",
            minSpotColor: "#2273e5",
            maxSpotColor: "#2273e5",
            highlightSpotColor: "#808996",
            highlightLineColor: "#808996",
            spotRadius: 0,
            chartRangeMin: 5,
            chartRangeMax: 10,
            chartRangeMinX: 5,
            chartRangeMaxX: 5,
            normalRangeMin: 5,
            normalRangeMax: 5,
            normalRangeColor: "#ebf5f9",
            drawNormalOnTop: !0
        });

var ctx = document.getElementById("bar-chart");
Chart.defaults.global.defaultFontFamily = "yekan",
    Chart.defaults.global.defaultFontSize = 14,
    Chart.defaults.global.defaultFontStyle = "500",
    Chart.defaults.global.defaultFontColor = "#808996";
var chart = new Chart(ctx,
    {
        type: "bar",
        data: {
            labels: ["فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی"],
            datasets: [{
                label: "سفارش",
                data: [40, 35, 54, 40, 45, 60, 70, 65, 70, 90],
                backgroundColor: "#287dfa",
                hoverBackgroundColor: "#2273e5",
                pointBackgroundColor: "#fff",
                borderWidth: 0,
                pointRadius: 4
            }]
        },
        options: {
            tooltips: {
                backgroundColor: "#1c2540"
            },
            legend: {
                display: !1
            },
            scales: {
                xAxes: [{
                    ticks: {
                        fontFamily: "yekan"
                    },
                    barPercentage: .4,
                    barThickness: 15,
                    display: !0,
                    gridLines: {
                        offsetGridLines: !1,
                        display: !1
                    }
                }],
                yAxes: [{
                    display: !0,
                    gridLines: {
                        color: "#eee"
                    },
                    ticks: {
                        fontSize: 14,
                        fontFamily: "yekan"
                    }
                }]
            }
        }
    });