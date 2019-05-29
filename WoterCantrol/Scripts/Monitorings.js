﻿new Vue({
    el: '#my-form',
    data: {
        outputs: [],
        outputsName: {
            Id: "Id",
            IsWorking: "Sensor On",
            IsProduct: "Sensor Empty",
            DeliveryAddress: "Delivery Address",
            AutoDelivery: "Auto Delivery On",
            CountProduct: "Count Product for Delivery",
            ProductName: "Product Name",
            OwnerEmail: "Owner"
        }
    },
    methods: {
    },
    created() {
        var url1 = "/Home/GetMonitorings";
        var app = this;
        fetch(url1, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        })
            .then((response) => {
                if (response.ok) {
                    return response.json();
                }

                throw new Error('Network response was not ok');
            })
            .then((json) => {
                if (typeof json == "string")
                    alert(json);
                else {
                    json.forEach(function (item, i, arr) {
                        var autoDelivery = "No";
                        if (item.AutoDelivery) {
                            autoDelivery = "Yes"
                        };
                        var isproduct = "-";
                        var work = "No";
                        if (item.IsWorking) {
                            work = "Yes";
                            if (item.IsProduct) {
                                isproduct = "No";
                            }
                            else {
                                isproduct = "Yes";
                            }
                        }
                        var observer = item.ObserverEmail;
                        if (item.ObserverEmail == getCookie("email")) {
                            observer = "You";
                        }
                        app.outputs.push({
                            Id: item.Id,
                            IsWorking: work,
                            IsProduct: isproduct,
                            DeliveryAddress: item.DeliveryAddress,
                            AutoDelivery: autoDelivery,
                            CountProduct: item.CountProduct,
                            ProductName: item.ProductName,
                            OwnerEmail: observer
                        });
                    });
                }
            })
            .catch((error) => {
                console.log(error);
            });
    }
});