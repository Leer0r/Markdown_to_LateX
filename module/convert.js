const convert_md_to_latex = txt => {

    if(!/\S+/.test(txt)) return '';

    let translation = headerText;

    let matches;

    txt = txt.replace(markdown.multipleLines.regex, markdown.multipleLines.latex);

    let txts = txt.split('\n');

    txts.forEach(tx => {

        matches = null;



        
        matches = tx.match(markdown.header.regex);
        
        if(matches !== null) {
            console.log(tx + ' '.repeat(30-tx.length) + "--> header match, h" + matches[1].length);
        }



    });


    txt = txts.join('\n');

    translation += txt;

    translation += footerText;

    return translation;
    
};


const markdown = {
    header: {
        regex: /^(#{1,6})\s+.*$/,
        latex: ''
    },

    multipleLines: {
        regex: /\n{2,}/g,
        latex: '\n\n'
    }
};



const headerText = `\\documentclass[12pt, a4paper]{article}

\\begin{document}

\\usepackage[utf8]{inputenc}
\\usepackage[T1]{fontenc}\n\n`;

const footerText = `\n\n\\end{document}`;