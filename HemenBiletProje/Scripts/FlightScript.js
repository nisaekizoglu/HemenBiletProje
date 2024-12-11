document.addEventListener("DOMContentLoaded", function () {
    const tripTypeInputs = document.querySelectorAll('input[name="tripType"]');
    const returnDateContainer = document.getElementById("returnDateContainer");

    // Gidiþ-Dönüþ seçeneðine göre dönüþ tarihi alanýný göster/gizle
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

    // Nereden ve Nereye alanlarýný yer deðiþtir
    const swapIcon = document.getElementById("swapIcon");
    swapIcon.addEventListener("click", function () {
        const fromInput = document.getElementById("from");
        const toInput = document.getElementById("to");
        const tempValue = fromInput.value;
        fromInput.value = toInput.value;
        toInput.value = tempValue;
    });
});
