var chai = require('chai');
var expect = chai.expect;
var day13 = require('../day13.js');
var file = require('../file.js');
var path = require('path');

describe('Day 13', () => {
    it('Part 1 ex', () => {
        var result = day13.part1('0: 3\r\n1: 2\r\n4: 4\r\n6: 4');
        expect(result).to.equal(24);
    });

    it('Part 1', function(done) { 
        file.load(path.resolve(__dirname, '../day13.txt'), (data) => {
            var result = day13.part1(data);
            console.log("Day 13 result", result);
            expect(result).to.equals(1504).satisfy(done());
        });
    });

    it('Part 2 ex', () => {
        var result = day13.part2('0: 3\r\n1: 2\r\n4: 4\r\n6: 4');
        expect(result).to.equal(10);
    });

    // it('Part 2', function(done) { 
    //     file.load(path.resolve(__dirname, '../day13.txt'), (data) => {
    //         var result = day13.part2(data);
    //         console.log("Day 13 result", result);
    //         expect(result).to.equals(213).satisfy(done());
    //     });
    // });
});