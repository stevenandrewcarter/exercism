function DnaTranscriber() {
    this.toRna = function (dna) {
        var rna = "";
        for (var i = 0; i < dna.length; i++) {
            switch (dna[i]) {
                case 'G':
                    rna += 'C';
                    break;
                case 'C':
                    rna += 'G';
                    break;
                case 'T':
                    rna += 'A';
                    break;
                case 'A':
                    rna += 'U';
                    break;
            }
        }
        return rna;
    }
}

module.exports = DnaTranscriber;
