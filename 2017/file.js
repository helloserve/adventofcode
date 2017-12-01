var fs = require('fs');

function File() {

    this.load = function(filename, func) {
        fs.readFile(filename, 'utf8', (err, data) => {
            if (err) throw err;
            func(data);
        });
    }

}

module.exports = File;