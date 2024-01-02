# BookManager
A wireframe of a public library software to showcase a 'real' c# project with EF

The project is divided in 2 versions:
- one with async calls and Dependency Injection
- a simpler version without async calls and Dependency Injection

Whichever version you choose to experiment with the code try adding these functionalities for the library users:

- Lookup authors (by their name) and their books (with all the books' informations as well)
- Borrow and return a book (by book Id)
    - Display a message in case of a late return
    - A bit harder: since the application doesn't take in account book quantities and just assumes that every book is available in 1 copy, try adding a new table to check how many copies a book have and then manage the number of copies after borrowing/returning.
- Extend the borrow of 1 month starting from the original due date
    - Display a message in case today's date is alread over the new extended date
- Introduce a new first step of authentication through membership card number
    - Display a personalized welcome message
        - Display a special message if it's the user's birthday
    - Manage logout
- Optional: introduce a way to borrow a book after a Lookup (author or books) without going back to the main menu and the borrow by Id

The code has a lot on it but it can be made better, try some refactoring to make it look better and to avoid repetitions and over-complicated statements.






