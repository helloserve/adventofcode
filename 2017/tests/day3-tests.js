var chai = require('chai');
var expect = chai.expect;
var day3 = require('../day3.js');

describe('Day 3', () => {

    it('Part 1 [1]', () => {
        var result = day3.part1(1);
        expect(result).to.equal(0);
    });

    it('Part 1 [12]', () => {
        var result = day3.part1(12);
        expect(result).to.equal(3);
    });

    it('Part 1 [23]', () => {
        var result = day3.part1(23);
        expect(result).to.equal(2);
    });

    it('Part 1 [1024]', () => {
        var result = day3.part1(1024);
        expect(result).to.equal(31);
    });

    it('Part 1', () => {
        var result = day3.part1(325489);
        expect(result).to.equal(552);
    });

    it('Part 2', () => {
        var result = day3.part2(325489);
        expect(result).to.equal(330785);
    });
});