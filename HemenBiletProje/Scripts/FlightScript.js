document.addEventListener("DOMContentLoaded", function () {
    const tripTypeInputs = document.querySelectorAll('input[name="tripType"]');
    const returnDateContainer = document.getElementById("returnDateContainer");
    const contactLink = document.getElementById("contactLink");
    const contactPopup = document.getElementById("contactPopup");
    const closePopup = document.getElementById("closePopup");

    // Gidi�-D�n�� se�ene�ine g�re d�n�� tarihi alan�n� g�ster/gizle
    tripTypeInputs.forEach(input => {
        input.addEventListener("change", function () {
            if (this.value === "round-trip") {
                returnDateContainer.style.display = "flex";
                document.getElementById("returnDate").setAttribute("required", "required");
            } else {
                returnDateContainer.style.display = "none";
                document.getElementById("returnDate").removeAttribute("required");
            }
        });
    });

    // �leti�im linkine t�klan�nca pop-up'� g�ster
    contactLink.addEventListener("click", function (event) {
        event.preventDefault(); // Linkin varsay�lan davran���n� engelle
        contactPopup.style.display = "flex"; // Pop-up'� g�ster
    });

    // �arp� i�aretine t�klan�nca pop-up'� kapat
    closePopup.addEventListener("click", function () {
       
        contactPopup.style.display = "none"; // Pop-up'� gizle
    });

    // Pop-up d���na t�klan�nca pop-up'� kapat
    contactPopup.addEventListener("click", function (event) {
        if (event.target === contactPopup) {
            contactPopup.style.display = "none"; // Pop-up'� gizle
        }
    });

    // Nereden ve Nereye alanlar�n� yer de�i�tir
    const swapIcon = document.getElementById("swapIcon");
    swapIcon.addEventListener("click", function () {
        const fromInput = document.getElementById("from");
        const toInput = document.getElementById("to");
        const tempValue = fromInput.value;
        fromInput.value = toInput.value;
        toInput.value = tempValue;
    });
});
