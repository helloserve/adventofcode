var fs = require('fs');

load = function(filename, func) {
        fs.readFile(filename, 'utf8', (err, data) => {
            if (err) throw err;
            func(data);
        });
    }

module.exports = { load };