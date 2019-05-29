new Vue({
    el: '#my-form',
    data: {
        inputs: [
            { Id: "ObserverEmail", name: "Observer Email", type: "email", value: "" },
            { Id: "DeliveryAddress", name: "Product Delivery Address", type: "text", value: "" },
            { Id: "CountProduct", name: "Count Product for Delivery", type: "text", value: "" }
        ],
        radioInputs1: { Id: "AutoDeliveryYes", name: "AutoDelivery", label: "Auto Delivery", type: "radio", value: "Yes" },
        radioInputs2: { Id: "AutoDeliveryNo", name: "AutoDelivery", label: "Auto Delivery", type: "radio", value: "No" },
        radioInputs3: { Id: "IsWorkingYes", name: "IsWorking", label: "Sensor Working", type: "radio", value: "On" },
        radioInputs4: { Id: "IsWorkingNo", name: "IsWorking", label: "Sensor Working", type: "radio", value: "Off" }

    },
    created() {
        url1 = "/Sensor/GetSensorById";
        id_ = window.id;
        url2 = "?Id=" + id_;
        app = this;
        fetch(url1 + url2, {
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
                if (typeof json == "string") {
                    alert(json);
                }
                else {
                    app.inputs.forEach(function (item, i, arr) {
                        item.value = json[item.Id];
                    });
                    if (json.AutoDelivery) {
                        document.getElementById("AutoDeliveryYes").checked = true;
                    }
                    else {
                        document.getElementById("AutoDeliveryNo").checked = true;
                    }
                    if (json.IsWorking) {
                        document.getElementById("IsWorkingYes").checked = true;
                    }
                    else {
                        document.getElementById("IsWorkingNo").checked = true;
                    }
                }
            })
            .catch((error) => {
                console.log(error);
            });
    }
});
$("form").submit(function (event) {
    event.preventDefault();

    var url = "/Sensor/EditSensor";
    var ownerEmail_ = $('#ObserverEmail').val();
    var name_ = $('#Name').val();
    var deliveryAddress_ = $('#DeliveryAddress').val();
    var countProduct_ = $('#CountProduct').val();
    var autoDelivery_ = true;
    if (document.getElementById("AutoDeliveryNo").checked) {
        autoDelivery_ = false;
    }
    var isWorking = true;
    if (document.getElementById("IsWorkingNo").checked) {
        isWorking = false;
    }
    fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            Id: window.id,
            ObserverEmail: ownerEmail_,
            CountProduct: countProduct_,
            DeliveryAddress: deliveryAddress_,
            IsWorking: isWorking,
            AutoDelivery: autoDelivery_
        })
    })
        .then((response) => {
            if (response.ok) {
                return response.json();
            }

            throw new Error('Network response was not ok');
        })
        .then((json) => {
            console.log(json);
            alert(json);
        })
        .catch((error) => {
            console.log(error);
        });
});