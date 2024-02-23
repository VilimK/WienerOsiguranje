function AjaxGetDetailsAboutPartnerWithID(partnerId) {
    $.ajax({
        url: '/Home/GetPartnerDetails',
        method: 'POST',
        data: { id: partnerId },
        success: function (response) {
            DisplayDataInModal(response);
        },
        error: function (xhr, status, error) {
            console.error(error);
        }
    });
}

function AjaxRedirectToAddNewPartnerPage() {
    $.ajax({
        url: '/StaticContent/ServeContent',
        data: { filename: 'newpartner.html' },
        method: 'GET',
        success: function (response) {
            window.location.href = response;
        },
        error: function (xhr, status, error) {
            console.error(error);
        }
    });
}


function AjaxSendNewPartnerData(firstName, lastName, address, partnerNumber, croatianPIN, partnerTypeId, createdByUser, externalCode, isForeign, gender) {
    $.ajax({
        url: '/AddNewPartner/CreateNewPartner',
        data: {
            firstName: firstName,
            lastName: lastName,
            address: address,
            partnerNumber: partnerNumber,
            croatianPIN: croatianPIN,
            partnerTypeId: partnerTypeId,
            createdByUser: createdByUser,
            isForeign: isForeign,
            externalCode: externalCode,
            gender: gender
        },
        method: 'GET',
        success: function (response) {
        },
        error: function (xhr, status, error) {
            console.error(error);
        }
    });
}

function AjaxAddNewPolicy(partnerNumber, amount) {
    $.ajax({
        url: '/AddNewPolicy/AddNewPolicyWithPartnerNumber',
        data: {
            partnerNumber: partnerNumber,
            amount: amount
        },
        method: 'GET',
        success: function (response) {
            if (response) alert("New policy created.");
        },
        error: function (xhr, status, error) {
            console.error(error);
        }
    });
}

