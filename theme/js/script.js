window.onload = () => {
    
    // drop handler

    /**
     * On file drop handler
     * @param {Object} e event
     */
    const dropHandler = e => {
        
    };


    /**
     * Returns markdown textarea's text. If textarea not found, returns empty string
     * @return {string}
     */
    const getMdText = () => {
        const mdArea = document.querySelector("#box-md textarea");

        if(mdArea) {
            return mdArea.value;
        }

        return "";
    };


    // convert handler
    const convertBtn = document.getElementById("convert-button");

    const outputArea = document.querySelector("#box-latex textarea");

    if(convertBtn) {
        convertBtn.addEventListener("click", () => {
            if(outputArea) {
                outputArea.value = convert_md_to_latex(getMdText());
            }
        });
    }
};