function CreatePartnersTable(partnersData) {
    var header = ["Full name", "Partner number", "Croatian PIN(OIB)", "Partner type ID", "Created at (UTC)", "Is foreign", "Gender"];
    const body = document.body;
    var table = document.createElement("table");
    table.id = "partnersTable";

    //Prvi redak - Header
    var row = table.insertRow();
    row.className = "headRow";
    for (let i = 0; i < header.length; i++) {
        var cell = row.insertCell();
        cell.id = "head" + header[i];
        cell.value = header[i];
        cell.textContent = header[i];
        cell.class = "headerCell"; 
    }

    row.insertCell();

    partnersData.forEach(function (item) {
        var row = table.insertRow();
        row.id = item.PartnerId;
        row.addEventListener("click", DisplayPartnerDataInModal);  

        var cell = row.insertCell();
        cell.value = item.FullName;
        cell.textContent = item.FullName;

        var cell = row.insertCell();
        cell.value = item.PartnerNumber;
        cell.textContent = item.PartnerNumber;

        var cell = row.insertCell();
        cell.value = item.CroatianPIN;
        cell.textContent = item.CroatianPIN;

        var cell = row.insertCell();
        cell.value = item.PartnerTypeID;
        cell.textContent = item.PartnerTypeID;

        var cell = row.insertCell();
        cell.id = item.partnerId + "date"; 
        cell.value = item.CreatedAtUtc;
        cell.textContent = item.CreatedAtUtc;

        var cell = row.insertCell();
        cell.value = item.IsForeign;
        cell.textContent = item.IsForeign;

        var cell = row.insertCell();
        cell.value = item.Gender;
        cell.textContent = item.Gender;

        var cell = row.insertCell();
        AddTableButton("AddPolicy", "Add policy", cell, item.PartnerNumber);
    });
    body.appendChild(table);
}

function AddTableButton(name, value, cell, partnerID) {
    var btn = document.createElement("button");
    btn.id = partnerID;
    btn.name = name;
    btn.value = value;
    btn.textContent = value;
    if (name === "AddPolicy") {
        btn.addEventListener("click", DisplayAddPolicyModal);
        btn.className = "addBtn";
    }
    cell.appendChild(btn);
}

function DisplayAddPolicyModal() {
    document.getElementById("addPolicyModalHeader").innerHTML = "Create policy for partner with number " + this.id;
    document.getElementById("policyAddModal").style.display = "block"; 
    event.stopPropagation();
}

function DisplayPartnerDataInModal() {
    document.getElementById('partnerDetailModal').style.display = 'block';
    var partnerId = this.id;
    AjaxGetDetailsAboutPartnerWithID(partnerId);
}



function DisplayDataInModal(partnerData) {
    document.getElementById("detailFullName").innerHTML = "Full name: " + partnerData.FirstName + " " + partnerData.LastName;
    document.getElementById("detailAddress").innerHTML = "Address: " + partnerData.Address;  
    document.getElementById("detailPartnerNumber").innerHTML = "Partner number: " + partnerData.PartnerNumber; 
    document.getElementById("detailCroatianPIN").innerHTML = "Croatian PIN: " + partnerData.CroatianPIN; 
    document.getElementById("detailPartnerTypeId").innerHTML = "Partner type ID: " + partnerData.PartnerTypeId;
    document.getElementById("detailCreatedAtUtc").innerHTML = "Created at (UTC): " + document.getElementById(partnerData.partnerId + "date").value; 
    document.getElementById("detailCreateByUser").innerHTML = "Created by user: " + partnerData.CreateByUser; 
    document.getElementById("detailIsForeign").innerHTML = "Is foreign: " + partnerData.IsForeign; 
    document.getElementById("detailExternalCode").innerHTML = "External code: " + partnerData.ExternalCode; 
    document.getElementById("detailGender").innerHTML = "Gender: " + partnerData.Gender; 
}

function DisplayNewPartnerPage() {
    //Preusmjeravanje na stranicu za dodavanje novog partnera
    AjaxRedirectToAddNewPartnerPage();
}

function AddPolicy() {
    var partnerNumber = document.getElementById("addPolicyModalHeader").innerHTML;
    partnerNumber = partnerNumber.replace('Create policy for partner with number ', '');
    var inputElement = document.getElementById('policyAmount');
    var amount = inputElement.value;
    if (validateInput(amount)) {
        AjaxAddNewPolicy(partnerNumber, amount); 
    }
    else {
        return; 
    }
}

function validateInput(inputValue) {
    var pattern = /^\d{1,8}$/;

    if (pattern.test(inputValue)) return true;
    else {
        alert('Input is not valid.');
        return false;
    }
}
