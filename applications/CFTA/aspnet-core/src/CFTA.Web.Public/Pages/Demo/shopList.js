(function ($) {

    var filterType = getQueryVariable("filterType");

    setCheckBox(filterType);
    setSortSelect(filterType);
    setSearchBtnEvent();
    setSortSelectEvent();

    function setSortSelect(filterType) {
        if (filterType && filterType !== 0) {
            var sortType = getQueryVariables("sortType");
            $(`#shopListSortSelect option[value=${sortType}]`).attr("selected", true);
        }
    }

    function setSortSelectEvent() {
        $("#shopListSortSelect").change(function () {
            window.location.href = "/Demo/ShopList?" + buildQueryString();
        });
    }

    function setSearchBtnEvent() {
        $("#shopListSearchBtn").click(function (e) {
            e.preventDefault();
            window.location.href = "/Demo/ShopList?" + buildQueryString();
        });
    }

    function buildQueryString() {
        var queryStr = "filterType=1&";

        $(".categoryCheckBox").each(function () {
            if ($(this).is(':checked')) {
                queryStr += "categoryIds=" + $(this).val() + "&";
            }
        });

        var sortType = $("#shopListSortSelect").val();
        queryStr += "sortType=" + sortType;

        return queryStr;
    }

    function setCheckBox(filterType) {
        if (!filterType || filterType === 0) {
            $(".categoryCheckBox").each(function () {
                $(this).attr("checked", true);
            });
        } else {
            categoryIds = getQueryVariables("categoryIds");

            for (let i = 0; i < categoryIds.length; i++) {
                categoryIds[i] = categoryIds[i].toLowerCase();
            }

            $(".categoryCheckBox").each(function () {
                if (categoryIds.indexOf($(this).val().toLowerCase()) > -1) {
                    $(this).attr("checked", true);
                }
            });
        }
    }

    function getQueryVariable(variable) {
        var query = window.location.search.substring(1);
        var vars = query.split("&");
        for (var i = 0; i < vars.length; i++) {
            var pair = vars[i].split("=");
            if (pair[0] == variable) { return pair[1]; }
        }
        return (false);
    }

    function getQueryVariables(variable) {
        var query = window.location.search.substring(1);
        var vars = query.split("&");
        var result = [];
        for (var i = 0; i < vars.length; i++) {
            var pair = vars[i].split("=");
            if (pair[0] == variable) {
                result.push(pair[1]);
            }
        }
        return result;
    }
})(jQuery);
