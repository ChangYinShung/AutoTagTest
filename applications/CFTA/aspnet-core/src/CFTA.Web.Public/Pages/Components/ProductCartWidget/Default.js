const vueCartSelectorComponent = new Vue({
    el: '#vue-product-cart',
    data: {
        shopCartLocalStoreKey: "shop-cart",
        shopCarts: [],
        currency:'',
    },
    created() {
    },
    mounted() {
        let shopCarts = JSON.parse(localStorage.getItem(this.shopCartLocalStoreKey));

        this.shopCarts = shopCarts ?? [];
        this.currency = this.shopCarts.length > 0 ? this.shopCarts[0].skuCurrency : "";
    },
    methods: {
        // 購物車數量變更
        onQuantityChange: function (item) {
            item.amount = item.price * item.quantity;
        },

        // 刪除購物車資料
        deleteFormData: function (i) {
            this.shopCarts = this.shopCarts.filter((item, j) => i != j);
        }
    },
    watch: {
        shopCarts: {
            handler(val) {
                localStorage.setItem(this.shopCartLocalStoreKey, JSON.stringify(val));
            },
            deep: true
        }
    },
    computed: {
        total: function () {
            let total = 0;
            for (let i = 0; i < this.shopCarts.length; i++) {
                let item = this.shopCarts[i];
                let price = parseInt(item.price);
                let quantity = parseInt(item.quantity);
                let extraFee = parseInt(item.extraFee);

                item.totalExtraFee = extraFee * quantity;
                item.amount = price * quantity + item.totalExtraFee;
                total += item.amount;
            }

            return total;
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