require('./string.js');

part1 = (input) => {
    var lines = splitOnNewLine(input);
    var total = 0;
    
    lines.forEach((line, index) => {
        total += parseLine(line) ? 1 : 0;
    });
    console.log(total);
    return total;
}

part2 = (input) => {
    var lines = splitOnNewLine(input);
    var total = 0;
    
    lines.forEach((line, index) => {
        total += parseLine(line, true) ? 1 : 0;
    });
    console.log(total);
    return total;        
}

parseLine = (line, checkAnagram) => {
    var words = splitOnWhiteSpace(line);
    for (let i = 0; i < words.length; i++) {
        const word_i = words[i];
        
        for (let j = 0; j < words.length; j++) {
            const word_j = words[j];
            
            if (i == j) {
                continue;
            }

            if (word_i === word_j) {
                return false;
            }

            if (checkAnagram && isAnagram(word_i, word_j)) {
                return false;
            }
        }
    }

    return true;
}

isAnagram = (a, b) => {
    if (a.length !== b.length) {
        return false;
    }

    for (let i = 0; i < a.length; i++) {
        const a_letter = a[i];
        
        for (let j = 0; j < b.length; j++) {
            const b_letter = b[j];
            
            if (a_letter === b_letter) {
                var s = b.substr(0, j) + '-' + (j = b.length ? b.substr(j + 1) : '');
                b = s;
                break;
            }
        }
    }

    return (/^-*$/g).test(b);
}
    
module.exports =  { part1, part2 }
