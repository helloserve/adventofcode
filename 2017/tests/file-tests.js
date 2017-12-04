var chai = require('chai');
var expect = chai.expect;
var file = require('../file.js');

describe("File", function(done) {
    it ("File loads file", function() {
        var output = '';
        file.load('./file.txt'), (data) => { 
            expect(data).to.equal('you have mail').satisfy(done());
        }
    });
});