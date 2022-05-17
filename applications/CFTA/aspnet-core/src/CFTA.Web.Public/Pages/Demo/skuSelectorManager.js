var eshop = eshop || {};

(function ($) {

    eshop.skuSelectorSlotStatusTypeEnum = {
        choosable: 0,
        checked: 1,
        disable: 2,
    };

    eshop.SkuSelectorManager = (function () {

        var skuSelectorSlotStatusTypeEnum = eshop.skuSelectorSlotStatusTypeEnum;

        return function (product) {
            // 行数据
            var _skuSelectAttributes = [];

            // 所有的槽
            var _skuSelectSlots = [];

            // 所有可能的sku
            var _skus = [];

            var _publicApi = null;

            // 构建行数据
            product.productAttributes.forEach(function (currentProductAttribute) {
                var attribute = {
                    attributeId: currentProductAttribute.id,
                    displayName: currentProductAttribute.displayName,
                }

                attribute.optionIds = [];

                currentProductAttribute.productAttributeOptions.forEach(function (currentOptions) {
                    attribute.optionIds.push(currentOptions.id);
                });

                _skuSelectAttributes.push(attribute);
            });

            // 构建所有默认插槽二维数组
            for (var i = 0, imax = product.productAttributes.length; i < imax; i++) {
                var attribute = product.productAttributes[i];
                var row = [];

                for (var j = 0, jmax = attribute.productAttributeOptions.length; j < jmax; j++) {
                    row.push({
                        optionId: attribute.productAttributeOptions[j].id,
                        displayName: attribute.productAttributeOptions[j].displayName,
                        status: skuSelectorSlotStatusTypeEnum.choosable
                    });
                }

                _skuSelectSlots.push(row);
            }

            // 构建_sku
            product.productSkus.forEach(function (currentProductSku, index) {
                var sku = {
                    skuId: currentProductSku.id,
                    inventory: currentProductSku.inventory
                };

                // 与行数相同 默认值undefined
                sku.optionIds = new Array(_skuSelectAttributes.length);

                // 按照行索引 构建sku的optionIds数组
                currentProductSku.attributeOptionIds.forEach(function (currentOptionId) {

                    var attribute;

                    for (var i = 0, imax = _skuSelectAttributes.length; i < imax; i++) {
                        var currentAttribute = _skuSelectAttributes[i];
                        if (currentAttribute.optionIds.indexOf(currentOptionId) !== -1) {
                            attribute = currentAttribute;
                            break;
                        }
                    }

                    var index = _skuSelectAttributes.indexOf(attribute);
                    sku.optionIds[index] = currentOptionId;
                });

                _skus.push(sku);
            });

            refreshSlots();

            // 获取所有行标签
            function getAttributes() {
                var result = [];

                for (var i = 0, imax = _skuSelectAttributes.length; i < imax; i++) {
                    var attribute = _skuSelectAttributes[i];

                    result.push({
                        attributeId: attribute.attributeId,
                        displayName: attribute.displayName
                    });
                }

                return result;
            }

            // 获取所有槽数据
            function getSlots() {
                var result = [];

                for (var i = 0, imax = _skuSelectSlots.length; i < imax; i++) {
                    var row = [];

                    for (var j = 0, jmax = _skuSelectSlots[i].length; j < jmax; j++) {
                        var slot = _skuSelectSlots[i][j];
                        row.push({
                            optionId: slot.optionId,
                            status: slot.status,
                            displayName: slot.displayName
                        });
                    }

                    result.push(row);
                }

                return result;
            }

            // 选中或者取消一个槽
            function select(y, x)
            {
                var slot = _skuSelectSlots[y][x];

                if (slot.status === skuSelectorSlotStatusTypeEnum.choosable) {
                    check(y, x);
                }
                else if (slot.status === skuSelectorSlotStatusTypeEnum.checked) {
                    uncheck(y, x);
                }
            }

            // 选中一个槽
            function check(y, x) {
                var slot = _skuSelectSlots[y][x];

                if (slot.status != skuSelectorSlotStatusTypeEnum.choosable) {
                    return;
                }

                // 判断当前行是否有选中
                var rowSelectedIndex = getCurrentRowSelectedIndex(y);

                // 有选中取消设置
                if (rowSelectedIndex !== false) {
                    _skuSelectSlots[y][rowSelectedIndex].status = skuSelectorSlotStatusTypeEnum.choosable;
                }

                slot.status = skuSelectorSlotStatusTypeEnum.checked;
                refreshSlots();
            }

            // 取消选中一个槽
            function uncheck(y, x)
            {
                var slot = _skuSelectSlots[y][x];

                if (slot.status !== skuSelectorSlotStatusTypeEnum.checked) {
                    return;
                }

                slot.status = skuSelectorSlotStatusTypeEnum.choosable;
                refreshSlots();
            }

            // 获取某行中选中的列索引
            function getCurrentRowSelectedIndex(y) {
                for (var i = 0, imax = _skuSelectSlots[y].length; i < imax; i++)
                {
                    if (_skuSelectSlots[y][i].status === skuSelectorSlotStatusTypeEnum.checked) {
                        return i;
                    }
                }

                return false;
            }

            // 获取当前所有槽的选中情况
            function getCurrentSelected() {
                var result = new Array(_skuSelectAttributes.length);

                for (var i = 0, imax = _skuSelectSlots.length; i < imax; i++)
                {
                    for (var j = 0, jmax = _skuSelectSlots[i].length; j < jmax; j++)
                    {
                        var slot = _skuSelectSlots[i][j];

                        if (slot.status === skuSelectorSlotStatusTypeEnum.checked) {
                            result[i] = slot.optionId;
                            break;
                        }
                    }
                }

                return result;
            }

            // 刷新所有槽状态
            function refreshSlots() {
                var currentSelected = getCurrentSelected();

                for (var i = 0, imax = _skuSelectSlots.length; i < imax; i++)
                {
                    var copySelected = JSON.parse(JSON.stringify(currentSelected));

                    for (var j = 0, jmax = _skuSelectSlots[i].length; j < jmax; j++)
                    {
                        var slot = _skuSelectSlots[i][j];

                        if (slot.status === skuSelectorSlotStatusTypeEnum.checked) {
                            continue;
                        }

                        // 假定当前行选择了当前槽的值
                        copySelected[i] = slot.optionId;

                        var matched = false;

                        for (var k = 0, kmax = _skus.length; k < kmax; k++) {
                            var currentSku = _skus[k];

                            // 如果库存小于等于0则相当于没有这个sku存在 目前逻辑是否得区分之后再优化
                            if (currentSku.inventory <= 0) {
                                break;
                            }

                            var matchCount = 0;
                            for (var l = 0, lmax = copySelected.length; l < lmax; l++) {
                                // 有一样的值或者空值就匹配
                                if (copySelected[l] === currentSku.optionIds[l] || copySelected[l] === undefined || copySelected[l] === null) {
                                    matchCount++;
                                }
                            }

                            // 直到匹配数量和sku的可选值数量一样 并且库存大于0 则算完全匹配
                            if (matchCount === currentSku.optionIds.length) {
                                matched = true;
                                break;
                            }
                        }

                        slot.status = matched ? skuSelectorSlotStatusTypeEnum.choosable : skuSelectorSlotStatusTypeEnum.disable;
                    }
                }
            }

            // 获取选中的sku 如果当前未有选中完成的sku 则返回false
            function getSelectedSku() {
                var currentSelected = getCurrentSelected();
                var result = false;

                for (var i = 0, imax = _skus.length; i < imax; i++) {
                    var optionIds = _skus[i].optionIds;
                    var matched = 0;

                    for (var j = 0, jmax = currentSelected.length; j < jmax; j++) {
                        if (currentSelected[j] === optionIds[j]) {
                            matched++;
                        }

                    }

                    if (matched === optionIds.length) {
                        result = {
                            skuId: _skus[i].skuId,
                            inventory: _skus[i].inventory,
                            optionIds: _skus[i].optionIds
                        };

                        break;
                    }
                }

                return result;
            }

            _publicApi = {
                select: function (y, x) {
                    return select(y, x);
                },
                getSlots: function () {
                    return getSlots()
                },
                getAttributes: function () {
                    return getAttributes();
                },
                getSelectedSku: function () {
                    return getSelectedSku();
                }
            }

            return _publicApi;
        };
    })();
})(jQuery);