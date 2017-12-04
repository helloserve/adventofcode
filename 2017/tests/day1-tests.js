var chai = require('chai');
var expect = chai.expect;
var file = require('../file.js');
var day1 = require('../day1.js');
var path = require('path');

describe('Day 1', function() {
    it('Part 1 [1122]', function() {
        var result = day1.part1('1122');
        expect(result).to.equal(3);
    });

    it('Part 1 [1111]', function() {
        var result = day1.part1('1111');
        expect(result).to.equal(4);
    });

    it('Part 1 [1234]', function() {
        var result = day1.part1('1234');
        expect(result).to.equal(0);
    });

    it('Part 1 [91212129]', function() {
        var result = day1.part1('91212129');
        expect(result).to.equal(9);
    });

    it('Part 1', function(done) { 
        file.load(path.resolve(__dirname, '../day1.txt'), (data) => {
            var result = day1.part1(data);
            console.log("DAY1 result", result);
            expect(result).to.equals(1228).satisfy(done());
        });
    });

    it('Part 2 [1212]', function() {        
        var result = day1.part2('1212');
        expect(result).to.equal(6);
    });

    it('Part 2 [1221]', function() {
        var result = day1.part2('1221');
        expect(result).to.equal(0);
    });

    it('Part 2 [123425]', function() {
        var result = day1.part2('123425');
        expect(result).to.equal(4);
    });

    it('Part 2 [123123]', function() {
        var result = day1.part2('123123');
        expect(result).to.equal(12);
    });

    it('Part 2 [12131415]', function() {
        var result = day1.part2('12131415');
        expect(result).to.equal(4);
    });

    it('Part 2', function(done) { 
        file.load(path.resolve(__dirname, '../day1.txt'), (data) => {
            var result = day1.part2(data);
            console.log("DAY1 result", result);
            expect(result).to.equals(1238).satisfy(done());
        });
    });

});