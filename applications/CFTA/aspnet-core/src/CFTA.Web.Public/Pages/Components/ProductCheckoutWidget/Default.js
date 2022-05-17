const vueCartSelectorComponent = new Vue({
    el: '#vue-product-checkout',
    data: {
        // cache key
        shopCartLocalStoreKey: "shop-cart",
        userInfoLocalStoreKey: "user-info",

        // datas
        shopCarts: [],
        zipCodes: [],
        paymentGateways: [],
        citys: [],
        areas: [],

        // form
        formActions: "",
        formData: {
            firstName: "",
            lastName: "",
            phone: "",
            email: "",
            country: "Taiwan",
            nonTaiwanCity: "",
            taiwanCity: "",
            taiwanArea: "",
            taiwanZipCode: "",
            address: "",
            remark: "",
            paymentGateway: "",
            selectZipCode: {
                city: "",
                zipcode_area: ""
            }
        },
        fontStyles: {
            textAlign: 'right'
        },
        currency: '',
        toggle: false,
    },
    created() {
    },
    mounted() {
        this.paymentGateways = JSON.parse(this.$refs.input.getAttribute('data-payment-gateways'));
        this.shopCarts = JSON.parse(localStorage.getItem(this.shopCartLocalStoreKey)) ?? [];

        let formData = JSON.parse(localStorage.getItem(this.userInfoLocalStoreKey));
        if (formData) this.formData = formData;

        // set PaymentGateway default
        let paymentGatewayKeys = Object.keys(this.paymentGateways);
        if (this.paymentGateways != null && paymentGatewayKeys.length > 0 && paymentGatewayKeys.findIndex(x => x == this.formData.paymentGateway) < 0)
            this.formData.paymentGateway = paymentGatewayKeys[0];

        this.currency = this.shopCarts.length > 0 ? this.shopCarts[0].skuCurrency : '';

        this.getZipCodes();
    },
    methods: {
        // init zip codes
        getZipCodes: function () {
            this.zipCodes = JSON.parse(this.$refs.input.getAttribute('data-zip-codes'));
            this.citys = [... new Set(this.zipCodes.map(x => x.city_name))];

            if (this.citys.findIndex(x => x == this.formData.selectZipCode.city) < 0)
                this.formData.selectZipCode.city = this.citys[0];

            this.onCityChange();
        },

        // city change, set areas
        onCityChange: function () {
            this.areas = this.zipCodes
                .filter(x => x.city_name == this.formData.selectZipCode.city)
                .map(x => {
                    return {
                        displayName: x.zipcode + " " + x.name,
                        area: x.name,
                        zipcode: x.zipcode
                    }
                });

            if (this.areas.findIndex(x => x.displayName == this.formData.selectZipCode.zipcode_area) < 0)
                this.formData.selectZipCode.zipcode_area = this.areas[0].displayName;

            this.onAreaChange();
        },

        // area change, set formData
        onAreaChange: function () {
            let areaItem = this.areas
                .find(x => x.displayName == this.formData.selectZipCode.zipcode_area)

            this.formData.taiwanArea = areaItem?.area;
            this.formData.taiwanZipCode = areaItem?.zipcode;
        },

        // clear local storage
        clearLocalStorage: function () {
            localStorage.removeItem(this.shopCartLocalStoreKey);
        }
    },
    watch: {
        formData: {
            handler(val) {
                localStorage.setItem(this.userInfoLocalStoreKey, JSON.stringify(val));
            },
            deep: true
        }
    },
    computed: {
        //檢查有無商品選擇是否禁用結帳按鈕
        disabled: function () {
            return !this.shopCarts || this.shopCarts.length == 0
        },
        subtotal: function () {
            let sum = 0;
            for (let i = 0; i < this.shopCarts.length; i++) {
                sum += parseInt(this.shopCarts[i].amount);
            }
            return sum;
        },
        isTaiwan: function () {
            return this.formData.country == "Taiwan";
        },
        shipping: function () {
            return this.isTaiwan ? 0 : 200;
        },
        total: function () {
            return this.subtotal + this.shipping;
        },
        formAction: function () {
            let gateway = this.paymentGateways[this.formData.paymentGateway];
            return gateway?.PrePaymentUrl;
        }
    },
    filters: {
        // 加上千分位符號
        commaFormat: function (value) {
            return value
                .toString()
                .replace(/^(-?\d+?)((?:\d{3})+)(?=\.\d+$|$)/, function (all, pre, groupOf3Digital) {
                    return pre + groupOf3Digital.replace(/\d{3}/g, ',$&');
                });
        }
    }
})