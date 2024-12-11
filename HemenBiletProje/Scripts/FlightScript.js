document.addEventListener("DOMContentLoaded", function () {
    const tripTypeInputs = document.querySelectorAll('input[name="tripType"]');
    const returnDateContainer = document.getElementById("returnDateContainer");

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
