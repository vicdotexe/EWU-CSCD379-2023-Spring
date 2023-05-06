import { Word } from '@/scripts/word'
import { WordsService } from './wordsService'
import { LetterStatus, type Letter } from './letter'
import { Player } from './playerService'
import Axios from 'axios';

export enum WordleGameStatus {
  Active = 0,
  Won = 1,
  Lost = 2
}

export class WordleGame {
  constructor(secretWord?: string, numberOfGuesses: number = 6) {
    if (!secretWord) secretWord = WordsService.getRandomWord()
    this.numberOfGuesses = numberOfGuesses
    this.restartGame(secretWord)
  }
  guessedLetters: Letter[] = []
  guesses = new Array<Word>()
  secretWord = ''
  status = WordleGameStatus.Active
  guess!: Word
  numberOfGuesses = 6
  startTime!: Date

  // // check length of guess
  //   if (this.letters.length !== secretWord.length) {
  //     console.log('wrong length')
  //     return
  //   }

  async restartGame(secretWord: string, numberOfGuesses: number = 6) {
    this.secretWord = secretWord
    this.guesses.splice(0)

    for (let i = 0; i < numberOfGuesses; i++) {
      const word = new Word()
      this.guesses.push(word)
    }
    this.guess = this.guesses[0]
    this.status = WordleGameStatus.Active
    this.startTime = new Date();
  }

  submitGuess() {
    // put logic to win here.
    this.guess.check(this.secretWord)

    if (this.guess.letters.every(l => l.status == LetterStatus.Correct)){
      this.endGame(true);
    }
    // Update the guessed letters
    for (const letter of this.guess.letters) {
      this.guessedLetters.push(letter)
    }

    console.log(this.guessedLetters)

    const index = this.guesses.indexOf(this.guess)
    if (index < this.guesses.length - 1) {
      this.guess = this.guesses[index + 1]
    } else {
      // The game is over
      this.endGame(false);
    }
  }

  endGame(win: boolean){
    const elapsedMs = (new Date()).getMilliseconds() - this.startTime.getMilliseconds();
    const guesses = this.guesses.indexOf(this.guess);
    
    const gameResult = {
      PlayerId: Player.Id.value,
      Attempts: guesses,
      Duration: elapsedMs,
      Success: win
    }

    Axios.post('/gameresult', gameResult).then(response => console.log(response));
  }
}
