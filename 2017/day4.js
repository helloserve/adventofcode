var File = require('./file.js');

function Day4() {

    this.part1File = (filepath, callback) => new File().load(filepath, (data) => callback(this.part1(data)));

    this.part1 = (input) => {
        var lines = input.split('\r\n');
        var total = 0;
        
        lines.forEach((line, index) => {
            total += this.parseLine(line) ? 1 : 0;
        });
        console.log(total);
        return total;
    }

    this.part2File = (filepath, callback) => new File().load(filepath, (data) => callback(this.part2(data)));

    this.part2 = (input) => {
        var lines = input.split('\r\n');
        var total = 0;
        
        lines.forEach((line, index) => {
            total += this.parseLine(line, true) ? 1 : 0;
        });
        console.log(total);
        return total;        
    }

    this.parseLine = (line, checkAnagram) => {
        var words = line.split(/\s/);        
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

                if (checkAnagram && this.isAnagram(word_i, word_j)) {
                    return false;
                }
            }
        }

        return true;
    }

    this.isAnagram = (a, b) => {
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
}
    
module.exports = Day4;

new Day4().part2('abcde xyz ecdab')