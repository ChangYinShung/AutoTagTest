(function ($) {
    var product = JSON.parse($("#productJson").val());
    var skuSelectorManager = new eshop.SkuSelectorManager(product);
    var skuSelectorSlotElements = [];
    var originalSkuPriceContent = $("#skuPrice").text();

    // 当前选中的sku
    var currentSelectedSku = null;

    var $skuSelectorRows = $("#skuSelector .skuSelectorRow");

    $skuSelectorRows.each(function (rowIndex) {
        var row = [];
        var $slots = $(this).find("li");

        $slots.each(function (colIndex) {
            row.push($(this));
            $(this).click(function () {
                if ($(this).attr("class") === "disabled") {
                    return;
                }

                skuSelectorManager.select(rowIndex, colIndex);
                refreshSlots();
                currentSelectedSku = refreshSkuPriceInventoryAndGetSku();
            });
        })

        skuSelectorSlotElements.push(row);
    });

    function refreshSlots() {
        var slots = skuSelectorManager.getSlots();

        for (var i = 0, imax = slots.length; i < imax; i++) {
            for (var j = 0, jmax = slots[i].length; j < jmax; j++) {
                var $slot = skuSelectorSlotElements[i][j];
                var slot = slots[i][j];

                switch (slot.status) {
                    case eshop.skuSelectorSlotStatusTypeEnum.choosable:
                        $($slot).attr("class", "");
                        break;
                    case eshop.skuSelectorSlotStatusTypeEnum.checked:
                        $($slot).attr("class", "active");
                        break;
                    case eshop.skuSelectorSlotStatusTypeEnum.disable:
                        $($slot).attr("class", "disabled");
                        break;
                }
            }
        }
    }

    function refreshSkuPriceInventoryAndGetSku() {
        var selectedSku = skuSelectorManager.getSelectedSku();
        var sku = null;

        if (!selectedSku) {
            $("#skuPrice").text(originalSkuPriceContent);
            $("#skuInventory").text("");
        } else {
            sku = product.productSkus.filter(p => p.id === selectedSku.skuId)[0];
            $("#skuPrice").text("NT$" + sku.price);
            $("#skuInventory").text("庫存:" + sku.inventory);
        }

        return sku;
    }
})(jQuery);
