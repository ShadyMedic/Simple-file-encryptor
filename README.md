# Simple file encryptor
Do you have a text file on your computer that stores some kind of sensitive information (passwords, internet links or something else you want to protect)?
Then this application is what you are looking for. True, it won't protect your files well enough to be safe against NSA, FBI, KGB or BIS agents, but your friends, family or people you share a computer with have pretty much no chance at getting to your information. Not even system administrators.

### How does it work? Very simply.
1) You open the application
2) You select the file you want to encrypt
3) You choose any password (it can be really anything - length or characters don't matter)
4) You confirm the operation
5) Poof! Your sensitive data are safe!

### Do you need to read your data again? Decrypting is just as simple.
1) You open the application
2) You select the file you want to decrypt
3) You enter the password you used for encryption
4) You confirm the operation
5) Bang! Your data are readable for you again!

### What happens, if somebody uses the wrong password for decrypting?
In case somebody will try to guess your password by typing names of your pets, children or dates of birth, he "will" decrypt the file. The problem is, that file won't actually be decrypted. It will look like the decryption was successful but the data in the file won't be the same as in the original file.
This is a big advantage, if you store passwords in your file, especially if they are random combinations of characters (as passwords should be). If somebody decrypts such file with a wrong password, he or she will have no method of proving they used the correct password, because they will get randomly-looking characters no matter what.

### What type of files can I protect using this?
You can encrypt and decrypt any type of files, that is stored as plain text. That includes files with extension `.txt`, but also all source files (`.c`,`.cpp`,`.cs`,`.py`,`.html`,`.xml`,...) and some files containing formated text (such as `.md` markdown files).
Binary files (pictures, videos, sounds, other applications,...) will usually get corrupted while encryption and lost, so I don't recommend using this application to protect them.

### What encryption do you use?
The application uses Vigenère cipher to encrypt and decrypt the data. That means, that it uses your password to decrypt the data. It works like this. Imagine, you are encoding a file containing text `Undertale is a great game` with password `cutellamas`.

The password and data are written under each other, like this
```
U n d e r t a l e   i s   a   g r e a t   g a m e
c u t e l l a m a s c u t e l l a m a s c u t e l
```
Now, the numeric codes for the characters are added together to form a cipher text. For example, code for 85 for `U` and 99 for `c`. If we add these numbers together, we get 184, which is code for `©`. Because of that, the first character is encrypted as `©`.

Decryption works the same, just backwards.

### Screenshots
![Screenshot n. 1](https://i.postimg.cc/PqcCXNQM/1.png)
![Screenshot n. 2](https://i.postimg.cc/V6Cdd17P/2.png)
