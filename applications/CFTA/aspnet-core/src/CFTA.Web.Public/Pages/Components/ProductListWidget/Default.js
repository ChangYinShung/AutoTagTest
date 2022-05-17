

const vueCartSelectorComponent = new Vue({
    el: '#vue-product-list',
    data: {
        // api
        eshopPublicManagementProductViewAppService: fS.eShopManagement.public.products.productView,
        eshopProductAppService: easyAbp.eShop.products.products.product,
        eshopProductCategoryAppService: easyAbp.eShop.products.categories.category,
        eshopProductDetailAppService: easyAbp.eShop.products.productDetails.productDetail,
        mediaDescriptorApiUrl: "", // image base url

        // cache key
        shopCartLocalStoreKey: "shop-cart",

        // paged
        currentPage: 1,
        pageSize: 10,
        totalCount: 0,
        filter: "",

        storeId: "",

        // 分類列表
        categoryList: [],

        // 背號選項
        productRemarkOptions: [],

        // 當前頁面資料
        productViews: [],

        // 購物車資訊
        formDatas: [],

        // 產品 Model
        productModel: {
            productId: '',
            productName: '',
            quantity: 1,
            maxQuantity: 999,
            inventories: 999,
            showInventory: false,
            price: 0,
            skuCurrency:'',
            attributes: [],
            skus: [],
            skuId: null,
            skuName: '',
            selectOptions: {},
            productMediaResourceUrl: '',
            productDetail: null,
            selectBackNumber: '',
            remark: '',
            showInput: false,
            extraFee: 0
        },
        modalStatus: false,
        myModal: null,
        productAmount:0,
    },
    created() {
    },
    async mounted() {
        this.storeId = this.$refs.input.getAttribute('data-storeId');
        this.mediaDescriptorApiUrl = this.$refs.input.getAttribute('data-media-descriptor-api-url');
        this.productRemarkOptions = JSON.parse(this.$refs.input.getAttribute('data-back-numbers'));

        let shopCarts = JSON.parse(localStorage.getItem(this.shopCartLocalStoreKey));
        this.formDatas = shopCarts ?? [];

        await this.getCategories();
        await this.getProductViewList();

        this.myModal = new bootstrap.Modal(document.getElementById('quick-view'));
    },
    methods: {
        async getCategories() {
            let categories = await this.eshopProductCategoryAppService.getList({
                parentId: null
            });

            this.categoryList = categories.items
                .map(x => {
                    return {
                        id: x.id,
                        displayName: x.displayName,
                        check: true
                    }
                });
        },
        async getProductViewList() {
            let categoryIds = this.categoryList
                .filter(x => x.check == true)
                .map(x => x.id);

            if (categoryIds.length == 0)
                categoryIds = this.categoryList.map(x => x.id);

            let input = {
                storeId: this.storeId,
                categoryIds: categoryIds,
                maxResultCount: this.pageSize,
                skipCount: (this.currentPage - 1) * this.pageSize,
                sorting: "CreationTime desc",
                filter: this.filter
            };

            // 取得產品資料
            let productViewResult = await this.eshopPublicManagementProductViewAppService.getListV2(input);
            let productViewList = productViewResult.items;

            this.totalCount = productViewResult.totalCount;

            // 產品資料轉為 UI Model
            this.productViews = [];
            for (let i = 0; i < productViewList.length; i++) {
                let productView = productViewList[i];
                
                let item = {
                    productId: productView.id,
                    productName: productView.displayName,
                    productMediaResourceUrl: productView.mediaResources ?
                        this.mediaDescriptorApiUrl + productView.mediaResources :
                        null,
                    minPrice: productView.minimumPrice,
                    maxPrice: productView.maximumPrice
                };

                this.productViews.push(item);
            }
        },
        async changePage(page) {
            this.currentPage = page;
            await this.getProductViewList();
        },
        async getProductDetail(id) {
            let productDetail = await this.eshopProductDetailAppService.get(id);

            return productDetail.description;
        },

        // 由小至大排序
        arraySortBy: function (list, key) {
            list.sort(function (a, b) {
                return a[key] < b[key] ? 1 : -1;
            });
            return list;
        },

        // 加入購物車
        addCart: function (productModel, e) {
            if (!this.validProductModel) {
                return;
            };

            let selectRemark = this.productRemarkOptions.find(x => x.Name == productModel.remark);
            let price = parseInt(productModel.price);
            let quantity = parseInt(productModel.quantity);
            let totalExtraFee = productModel.extraFee * quantity;

            let item = {
                storeId: this.storeId,
                productId: productModel.productId,
                productSkuId: productModel.skuId,
                productName: productModel.productName,
                productSkuName: productModel.skuName,
                price: productModel.price,
                remark: productModel.showInput ? '客製︰' + productModel.remark : productModel.remark,
                extraFee: productModel.extraFee,
                totalExtraFee: totalExtraFee,
                quantity: quantity,
                amount: price * quantity + totalExtraFee,
                mediaResources: productModel.productMediaResourceUrl,
                skuCurrency: productModel.skuCurrency,
            };
            this.formDatas.push(item);

            productModel.selectBackNumber = this.productRemarkOptions[0].Name;
            productModel.quantity = null;

            this.selectProductRemarkOptions(productModel);
            this.selectInitOption(productModel);
            this.onSelectOptionChange(productModel);
            this.modalStatus = true;

            this.showAlert();
            this.myModal.hide();
        },

        // 設為預設 Attribute Option
        selectInitOption: function (productModel) {
            let selectOptions = {};
            for (let i = 0; i < productModel.attributes.length; i++) {
                let attr = productModel.attributes[i];
                selectOptions[attr.id] = attr.options[0].id
            }

            productModel.selectOptions = selectOptions;
        },

        // 選擇 Attribute Option
        onSelectOptionChange: function (productModel) {
            let selectOptions = [];
            for (let key in productModel.selectOptions) {
                selectOptions.push(productModel.selectOptions[key]);
            }

            let selectAttrOptionIds = selectOptions.sort().join();

            let sku = productModel.skus.find(x => {
                let skuAttrOptionIds = x.attributeOptionIds.sort().join();
                return skuAttrOptionIds == selectAttrOptionIds;
            });

            if (sku == null) {
                productModel.price = null;
                productModel.skuId = null;
                productModel.skuName = null;
                productModel.skuCurrency = null;
                productModel.quantity = 0;
                productModel.maxQuantity = 0;
                productModel.inventories = 0;
                productModel.productMediaResourceUrl = productModel.defaultProductMediaResourceUrl;
                return;
            }

            productModel.price = sku.price;
            productModel.skuId = sku.id;
            productModel.skuName = sku.name;
            productModel.skuCurrency = sku.currency;
            // 取大訂購量 = 單次最大訂購量與庫存數取小值
            productModel.maxQuantity = sku.orderMaxQuantity > sku.inventory ? sku.inventory : sku.orderMaxQuantity;
            productModel.inventories = sku.inventory;
            productModel.productMediaResourceUrl = sku.mediaResources ?
                this.mediaDescriptorApiUrl + sku.mediaResources :
                productModel.defaultProductMediaResourceUrl;
        },

        //將product的值寫入model
        setProductModel: async function (productView) {
            let product = await this.eshopProductAppService.get(productView.productId);
            let productDetial = await this.getProductDetail(product.productDetailId);

            let attributes = this.arraySortBy(product.productAttributes, 'creationTime')
                .map(attribute => {
                    attribute.productAttributeOptions = this.arraySortBy(attribute.productAttributeOptions, "creationTime");
                    return attribute;
                });

            // 1︰NoNeed，無庫存，不需顯示剩餘庫存量
            let showInventory = product.inventoryStrategy.toString() != "1";

            let productModel = {
                productId: product.id,
                productName: product.displayName,
                quantity: 1,
                maxQuantity: 999,
                inventories: 999,
                showInventory: showInventory,
                price: 0,
                skuCurrency: '',
                attributes: attributes.map(attribute => {
                    return {
                        id: attribute.id,
                        name: attribute.displayName,
                        options: attribute.productAttributeOptions.map(option => {
                            return {
                                id: option.id,
                                name: option.displayName
                            }
                        })
                    }
                }),
                skus: product.productSkus,
                skuId: null,
                skuName: '',
                selectOptions: null,
                defaultProductMediaResourceUrl: productView.productMediaResourceUrl,
                productMediaResourceUrl: '',
                productDetail: productDetial,
                selectBackNumber: this.productRemarkOptions[0].Name,
                remark: '',
                showInput: false,
                extraFee: 0
            };

            this.selectProductRemarkOptions(productModel);
            this.selectInitOption(productModel);
            this.onSelectOptionChange(productModel);

            this.productModel = productModel;
            this.myModal.show();
        },

        //將options的值存入
        setSelectAttrOptionIds(attributeId, optionId) {
            this.productModel.selectOptions[attributeId] = optionId;
            this.onSelectOptionChange(this.productModel);
        },

        //顯示提示框
        showAlert() {
            Swal.fire({
                title: '是否繼續購物',
                showDenyButton: true,
                confirmButtonText: '前往購物車',
                denyButtonText: '繼續購物',
            }).then((result) => {
                if (result.isConfirmed) {
                    location.href = "/e-shop/products/cart"
                } else if (result.isDenied) {
                    // console.log("cart");
                }
            })
        },

        // 選擇背號
        selectProductRemarkOptions(productModel) {
            let extraFee = 0;
            let showInput = false;
            let option = this.productRemarkOptions.find(x => x.Name == productModel.selectBackNumber);
            switch (option.Type) {
                case "none":
                    extraFee = 0;
                    showInput = false
                    break;
                case "other":
                    extraFee = 600;
                    showInput = true
                    break;
                default:
                    extraFee = 300;
                    showInput = false
                    break;
            }

            productModel.showInput = showInput;
            productModel.remark = showInput ? "" : option.Name;
            productModel.extraFee = extraFee;
        }

        //test: function () {
        //    this.$refs.status.setAttribute('data-bs-dismiss', 'test');
        //    console.log(this.$refs.status.getAttribute('data-bs-dismiss'));
        //}
    },
    watch: {
        formDatas: {
            handler(val) {
                localStorage.setItem(this.shopCartLocalStoreKey, JSON.stringify(val));
            },
            deep: true
        },
        "productModel.price": function () {
            this.productAmount = this.productModel.price;
        },
        "productModel.extraFee": function (newValue, oldValue) {
            this.productAmount -= oldValue;
            this.productAmount += newValue;
        }
    },
    computed: {
        validProductModel: function () {
            let validHasSku = this.productModel.skuId != null;
            let validQuantityIsNotNull = !(
                this.productModel.quantity == "" ||
                this.productModel.quantity == null ||
                this.productModel.quantity == "0"
            );
            let validMaxAndMinQuantity = !(
                parseInt(this.productModel.quantity) <= 0 ||
                parseInt(this.productModel.quantity) > parseInt(this.productModel?.maxQuantity ?? 999)
            );
            let validBackNumbers = !!this.productModel.remark;

            if (validHasSku && validQuantityIsNotNull && validMaxAndMinQuantity && validBackNumbers) return true;
            //this.$refs.status.setAttribute('data-bs-dismiss', 'test');
            //console.log(this.$refs.status.getAttribute('data-bs-dismiss'));
            return false;
        }
    },
    filters: {
        commaFormat: function (value) {
            // 加上千分位符號
            return value
                .toString()
                .replace(/^(-?\d+?)((?:\d{3})+)(?=\.\d+$|$)/, function (all, pre, groupOf3Digital) {
                    return pre + groupOf3Digital.replace(/\d{3}/g, ',$&');
                });
        }
    }
})