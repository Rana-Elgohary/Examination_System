INSERT INTO Course (Name, Hours)
VALUES
  ('C#', 40),
  ('HTML', 30),
  ('CSS', 45);
/////////////////////////////////
INSERT INTO Topic (Name, Course_ID)
VALUES
  ('Topic1', 1),
  ('Topic2', 2),
  ('Topic3', 1);

/////////////////////////////////////
INSERT INTO Exam (Duration, Course_ID)
VALUES
  (3, 1),
  (3, 2),
  (3, 3);


 ////////////////////////////////////

 INSERT INTO Question (Quest, Corr_Answer, OPt1_Answer, OPt2_Answer, OPt3_Answer, Type, Quest_Deg, Exam_ID) VALUES
('C# is an object-oriented programming language.', 'True', 'False', '', '', 'TF', 1, 1),
('What does IDE stand for?', 'Integrated Development Environment', 'Integrated Developer Environment', 'Integrated Developer Experience', 'Integrated Deployment Environment', 'MCQ', 1, 1),
('Which data type is used to represent a single character in C#?', 'char', 'string', 'int', 'bool', 'MCQ', 1, 1),
('How do you declare an integer variable in C#?', 'int x;', 'integer x;', 'x as Integer;', 'var x = 5;', 'MCQ', 1, 1),
('What is the purpose of the "using" directive in C#?', 'To import namespaces', 'To define a class', 'To declare variables', 'To handle exceptions', 'MCQ', 1, 1),
('In C#, the "++" operator increments the value by 1.', 'True', 'False', '', '', 'TF', 1, 1),
('C# is a case-sensitive programming language.', 'True', 'False', '', '', 'TF', 1, 1),
('In HTML, <p> tag is used for creating paragraphs.', 'True', 'False', '', '', 'TF', 1, 1),
('What is the default access modifier for members of a class in C#?', 'private', 'protected', 'public', 'internal', 'MCQ', 1, 1),
('C# supports multiple inheritance.', 'False', 'True', '', '', 'TF', 1, 1),
('What is the correct syntax for a single-line comment in C#?', '// This is a comment', '/* This is a comment */', '# This is a comment', '-- This is a comment', 'MCQ', 1, 1),
('HTML is a programming language.', 'False', 'True', '', '', 'TF', 1, 1),
('C# is platform-independent.', 'False', 'True', '', '', 'TF', 1, 1),
('HTML stands for Hyper Text Markup Language.', 'True', 'False', '', '', 'TF', 1, 1),
('C# is primarily used for web development.', 'False', 'True', '', '', 'TF', 1, 1),
('Which keyword is used to define a constant in C#?', 'const', 'final', 'static', 'readonly', 'MCQ', 1, 1),
('What is the purpose of the "try-catch-finally" statement in C#?', 'To handle exceptions', 'To declare variables', 'To create loops', 'To define methods', 'MCQ', 1, 1),
('What does the "this" keyword refer to in C#?', 'The current instance of the class', 'The base class', 'A static variable', 'The derived class', 'MCQ', 1, 1),
('Which keyword is used to prevent a class from being inherited in C#?', 'sealed', 'static', 'abstract', 'final', 'MCQ', 1, 1),
('What is the correct way to define a constructor in C#?', 'public ClassName() { }', 'public void ConstructorName() { }', 'Constructor ClassName() { }', 'void ClassName() { }', 'MCQ', 1, 1),
('How do you declare a multi-dimensional array in C#?', 'int[,] arrayName', 'int[] arrayName', 'int[][] arrayName', 'int arrayName[]', 'MCQ', 1, 1),
('What is the purpose of the "base" keyword in C#?', 'Refers to the base class', 'Indicates the end of a loop', 'Declares a base constructor', 'Returns the base address of a variable', 'MCQ', 1, 1),
('What is the correct syntax for declaring a method in C# that does not return anything?', 'void methodName()', 'returnType methodName()', 'methodName() : void', 'void methodName : return', 'MCQ', 1, 1),
('How do you declare an integer variable in C#?', 'int x;', 'integer x;', 'x as Integer;', 'var x = 5;', 'MCQ', 1, 1),
('Which of the following is NOT a valid C# access modifier?', 'friend', 'public', 'protected', 'private', 'MCQ', 1, 1),
('What is the purpose of the "try-catch-finally" statement in C#?', 'To handle exceptions', 'To declare variables', 'To create loops', 'To define methods', 'MCQ', 1, 1),
('What does the "this" keyword refer to in C#?', 'The current instance of the class', 'The base class', 'A static variable', 'The derived class', 'MCQ', 1, 1),
('Which keyword is used to prevent a class from being inherited in C#?', 'sealed', 'static', 'abstract', 'final', 'MCQ', 1, 1),
('What is the correct way to define a constructor in C#?', 'public ClassName() { }', 'public void ConstructorName() { }', 'Constructor ClassName() { }', 'void ClassName() { }', 'MCQ', 1, 1),
('How do you declare a multi-dimensional array in C#?', 'int[,] arrayName', 'int[] arrayName', 'int[][] arrayName', 'int arrayName[]', 'MCQ', 1, 1);


INSERT INTO Question (Quest, Corr_Answer, OPt1_Answer, OPt2_Answer, OPt3_Answer, Type, Quest_Deg, Exam_ID)
VALUES 
('HTML stands for Hyper Text Markup Language.', 'True', NULL, NULL, NULL, 'TF', 1, 2),
('Which tag is used to define an image in HTML?', '<img>', '<image>', '<src>', '<picture>', 'MCQ', 1, 2),
('HTML uses tags to define the structure of a webpage.', 'True', NULL, NULL, NULL, 'TF', 1, 2),
('What does the <br> tag represent in HTML?', 'Line break', 'Page break', 'Bold text', 'Italic text', 'MCQ', 1, 2),
('What is the correct HTML for making a hyperlink?', '<a href="url">link text</a>', '<link>link text</link>', '<a src="url">link text</a>', '<a>link text</a>', 'MCQ', 1, 2),
('HTML is a programming language.', 'False', NULL, NULL, NULL, 'TF', 1, 2),
('What is the correct HTML for inserting an image?', '<img src="image.jpg" alt="MyImage">', '<image src="image.jpg" alt="MyImage">', '<img alt="MyImage">image.jpg</img>', '<image alt="MyImage">image.jpg</image>', 'MCQ', 1, 2),
('Which HTML attribute specifies an alternate text for an image, if the image cannot be displayed?', 'alt', 'title', 'img-alt', 'src', 'MCQ', 1, 2),
('HTML can execute code on the client-side.', 'False', NULL, NULL, NULL, 'TF', 1, 2),
('What is the correct HTML for creating a hyperlink mailto: someone@example.com?', '<a href="mailto:someone@example.com">Send email</a>', '<a href="email:someone@example.com">Send email</a>', '<mail href="someone@example.com">Send email</mail>', '<a email="someone@example.com">Send email</a>', 'MCQ', 1, 2),
('Which HTML tag is used to define the footer of a document or section?', '<footer>', '<end>', '<bottom>', '<section>', 'MCQ', 1, 2),
('In HTML, <p> tag is used for creating paragraphs.', 'True', NULL, NULL, NULL, 'TF', 1, 2),
('Which tag is used to define a hyperlink in HTML?', '<a>', '<link>', '<href>', '<hyperlink>', 'MCQ', 1, 2),
('HTML uses tags to define the layout of a webpage.', 'True', NULL, NULL, NULL, 'TF', 1, 2),
('What is the correct HTML for creating a button?', '<button>Click me</button>', '<input type="button" value="Click me">', '<button value="Click me">', '<input>Click me</input>', 'MCQ', 1, 2),
('What does the <i> tag represent in HTML?', 'Italic text', 'Indent text', 'Inline text', 'Important text', 'MCQ', 1, 2),
('HTML can include JavaScript code.', 'True', NULL, NULL, NULL, 'TF', 1, 2),
('Which HTML element is used to display a scalar measurement within a range?', '<meter>', '<scale>', '<value>', '<range>', 'MCQ', 1, 2),
('Which HTML tag is used to define a navigation menu in HTML?', '<nav>', '<menu>', '<navigation>', '<nm>', 'MCQ', 1, 2),
('What is the correct HTML for making a drop-down list?', '<select>', '<dropdown>', '<input type="dropdown">', '<list>', 'MCQ', 1, 2),
('What is the purpose of the "using" statement in HTML?', 'Automatic disposal of resources', 'Declares a namespace', 'Imports classes', 'Declares a variable', 'MCQ', 1, 2),
('HTML stands for Hypertext Markup Language.', 'True', NULL, NULL, NULL, 'TF', 1, 2),
('Which HTML tag is used to define a table row in HTML?', '<tr>', '<table-row>', '<td>', '<th>', 'MCQ', 1, 2),
('HTML is a markup language used for structuring webpages.', 'True', NULL, NULL, NULL, 'TF', 1, 2),
('What is the correct HTML for adding a background color?', '<body style="background-color:yellow;">', '<background>yellow</background>', '<bg color="yellow">', '<background-color:yellow;">', 'MCQ', 1, 2),
('Which tag is used to define an unordered list in HTML?', '<ul>', '<ol>', '<list>', '<li>', 'MCQ', 1, 2),
('HTML can include CSS styles.', 'True', NULL, NULL, NULL, 'TF', 1, 2),
('What is the purpose of the "this" keyword in HTML?', 'Refers to the current instance of a class', 'Indicates a method return type', 'Marks a variable as constant', 'Declares a constructor', 'MCQ', 1, 2),
('What is the correct HTML for creating a hyperlink to another website?', '<a href="http://www.example.com">link text</a>', '<a src="http://www.example.com">link text</a>', '<link href="http://www.example.com">link text</link>', '<a>http://www.example.com</a>', 'MCQ', 1, 2),
('Which tag is used to define a heading in HTML?', '<h1>', '<heading>', '<head>', '<header>', 'MCQ', 1, 2);


INSERT INTO Question (Quest, Corr_Answer, OPt1_Answer, OPt2_Answer, OPt3_Answer, Type, Quest_Deg, Exam_ID) 
VALUES 
('CSS stands for Cascading Style Sheets.', 'True', NULL, NULL, NULL, 'TF', 1, 3),
('Which property is used to change the text color in CSS?', 'color', 'text-color', 'background-color', 'font-color', 'MCQ', 1, 3),
('CSS can be used to style HTML elements.', 'True', NULL, NULL, NULL, 'TF', 1, 3),
('Which CSS property is used to change the font size of an element?', 'font-size', 'text-size', 'font-style', 'text-style', 'MCQ', 1, 3),
('What is the correct CSS syntax for making all <p> elements red?', 'p { color: red; }', '<p style="color: red;">', 'p { text-color: red; }', 'paragraph { color: red; }', 'MCQ', 1, 3),
('CSS is used to define the layout of a webpage.', 'True', NULL, NULL, NULL, 'TF', 1, 3),
('Which CSS property is used to set the background color of an element?', 'background-color', 'color', 'background', 'bg-color', 'MCQ', 1, 3),
('In CSS, IDs are denoted by which symbol?', '#', '.', '@', '$', 'MCQ', 1, 3),
('Which CSS property is used to change the font family of an element?', 'font-family', 'text-font', 'font-style', 'text-style', 'MCQ', 1, 3),
('CSS can only be applied inline in HTML.', 'False', NULL, NULL, NULL, 'TF', 1, 3),
('What is the correct CSS syntax for setting the margin of an element?', 'margin: 10px;', 'margin: 10px 20px;', 'padding: 10px;', 'border: 1px solid black;', 'MCQ', 1, 3),
('CSS can be used to add animations to elements on a webpage.', 'True', NULL, NULL, NULL, 'TF', 1, 3),
('Which CSS property is used to make text bold?', 'font-weight', 'text-bold', 'bold', 'font-style', 'MCQ', 1, 3),
('In CSS, the "float" property is used for what purpose?', 'To move an element to the left or right of its container', 'To set the font size of text', 'To change the text color', 'To add spacing between elements', 'MCQ', 1, 3),
('CSS can be used to apply styles to elements based on their position in the document.', 'True', NULL, NULL, NULL, 'TF', 1, 3),
('Which CSS property is used to set the height of an element?', 'height', 'element-height', 'height-size', 'size', 'MCQ', 1, 3),
('What is the correct CSS syntax for setting the text alignment to center?', 'text-align: center;', 'align: center;', 'text-align: middle;', 'align: middle;', 'MCQ', 1, 3),
('CSS can be used to create responsive designs for different screen sizes.', 'True', NULL, NULL, NULL, 'TF', 1, 3),
('Which CSS property is used to add space between the border and content of an element?', 'padding', 'margin', 'spacing', 'border-spacing', 'MCQ', 1, 3),
('In CSS, which selector is used to select elements with a specific class?', '.class', '#id', 'class', 'element', 'MCQ', 1, 3),
('What is the correct CSS syntax for setting the width of an element to 100 pixels?', 'width: 100px;', 'size: 100px;', 'width: 100;', 'width: 100%;', 'MCQ', 1, 3),
('CSS can be used to create dropdown menus.', 'True', NULL, NULL, NULL, 'TF', 1, 3),
('Which CSS property is used to create rounded corners for an element?', 'border-radius', 'rounded-corners', 'corner-radius', 'border-style', 'MCQ', 1, 3),
('CSS can be used to apply styles to elements based on user interaction, such as hovering over an element.', 'True', NULL, NULL, NULL, 'TF', 1, 3),
('What is the correct CSS syntax for setting the font style to italic?', 'font-style: italic;', 'text-style: italic;', 'font: italic;', 'style: italic;', 'MCQ', 1, 3),
('In CSS, which selector is used to select elements with a specific ID?', '#id', '.class', 'id', 'element', 'MCQ', 1, 3),
('What is the correct CSS syntax for setting the background image of an element?', 'background-image: url("image.jpg");', 'image: url("image.jpg");', 'background: image("image.jpg");', 'image: background("image.jpg");', 'MCQ', 1, 3),
('CSS can be used to create multi-column layouts.', 'True', NULL, NULL, NULL, 'TF', 1, 3),
('Which CSS property is used to control the visibility of an element?', 'visibility', 'display', 'opacity', 'hidden', 'MCQ', 1, 3),
('In CSS, which selector is used to select all elements?', '*', 'all', 'element', 'select', 'MCQ', 1, 3);


  ///////////////////////////////////////

  INSERT INTO Instructor (Name, Address, Email, Password, Age, Img_Id, Salary, HiringDate)
VALUES
  ('Mahmoud Ouf', ' foad St', 'ouf.Alex@example.com', 'password123', 35, NULL, 50000.00, '2022-01-01'),
  ('Ghada kadous', 'roshdy St', 'ghada.Alex@example.com', 'securepass', 40, NULL, 60000.00, '2022-02-15'),
  ('Ayman Lotfy', ' roshdy St', 'ayman.Alex@example.com', 'pass1234', 30, NULL, 45000.00, '2022-03-20');

  ///////////////////////////////////////////
  INSERT INTO InstructorCourse (CrsId, InstructorId)
VALUES
  (1, 1),
  (2, 2),
  (3, 3);

  ///////////////////////////////////
INSERT INTO Track (Name, Description, Supervisor)
VALUES
  ('pd', 'This is a detailed description for Track1. It covers various topics related to programming and development, including software engineering principles, data structures, algorithms, and more.', 1),
  ('os', 'This is a comprehensive description for Track2. It focuses on operating systems concepts, such as process management, memory management, file systems, and concurrency.', 2),
  ('ai', 'This is an extensive description for Track3. It explores artificial intelligence and machine learning topics, including neural networks, natural language processing, computer vision, and deep learning techniques.', 3);

  ///////////////////////////////////
  INSERT INTO Track_Instructor (TrackId, Ins_Id)
VALUES
  (1, 1),
  (2, 2),
  (3, 3);
  ///////////////////////////////////////
  INSERT INTO Student (Name, Email, Password, Age, Address, Image_ID,TrackId)
VALUES
  ('Menna Osama', 'Menna.alex@gmail.com', 'password123', 20, '123 Main St', 'img1.jpg',1),
  ('Rana Mohamed', 'rana.alex@gmail.com', 'securepass', 22, '456 Oak St', 'img2.jpg',2),
  ('Salma ALi', 'Salma.alex@gmail.com', 'pass345', 22, '456 Oak St', 'img3.jpg',2),
    ('Maya Refaey', 'Maya.alex@gmail.com', 'pass567', 22, '456 Oak St', 'img4.jpg',1),
  ('Sara Mahmoud', 'Sara.alex@gmail.com', 'pass1234', 25, '789 Pine St', 'img5.jpg',3);


  ///////////////////////////////////////
  INSERT INTO StudentCourse (CrsId, StudentId)
VALUES
  (1, 1),
  (2, 1),
  (3, 1),
  (1, 2),
  (2, 2),
  (3, 2),
  (1, 3),
  (2, 3),
  (3, 3);