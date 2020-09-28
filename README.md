# Simple file encryptor
Do you have a text file on your computer that stores some kind of sensitive information (passwords, internet links or something else you want to protect)?
Then this application is what you are looking for. True, it won't protect your files well enough to be safe against NSA agents, but your friends, family or people you share a computer with have pretty much no chance at getting to your information. Not even system administrators.

### How does it work? Very simply.
1) You open the application
2) You select the file you want to encrypt
3) You choose any password (at least four characters long and containing a letter)
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
This is a big advantage, if you store passwords in your file, especially if they are random combinations of characters (as passwords should be). If somebody decrypts such file with a wrong password, they will have no way of telling they used the correct password, because they will get randomly-looking characters no matter what.

### What type of files can I protect using this?
From version 2.0, you can encrypt absolutely any type of file, no matter if it is stored as plain text or in binary. For earlier versions, you could encrypt only files stored as plain text (view README.md file of those version for more information).

### What encryption do you use?
The application uses an improved version of Vigenère cipher to encrypt and decrypt the data. That means, that it uses your password to encrypt and decrypt the data. The password itself is encrypted by a different method before using it to assure even higher security. Both the file and the password is then converted into series of bytes (numbers between 0 and 255 inclusive) and are added together. Decryption works the same, but the byte values are subtracted, not added.

### Screenshots
![Screenshot n. 1](https://i.postimg.cc/9Mbzqfjj/img1.png)
![Screenshot n. 2](https://i.postimg.cc/66HyWT0r/img2.png)
![Screenshot n. 3](https://i.postimg.cc/Bbw6Mw6Y/img3.png)
![Screenshot n. 4](https://i.postimg.cc/LsMbJ9TD/img4.png)
