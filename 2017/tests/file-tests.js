var chai = require('chai');
var expect = chai.expect;
var File = require('../file.js');

describe("File", function() {
    it ("File loads file", function() {
        var file = new File();
        var output = '';
        file.load('./file.txt'), (data) => { 
            expect(data).to.equal('you have mail');
        }
    });
});