# SmartEdu

SmartEdu is a proposed comprehensive Web application that can be used by students,
teachers, and parents/guardians. The proposed Web application will allow
various types of users to register and if they are students, they can track the academic
progress, access study material through links, receive updates on revision classes, and
so on. Students can view and monitor their scores and performance. Teachers can
update scores and extra classes information and add resources. With just a click,
parents/guardians can keep track of their respective wards’ performance.

## Functionalities

The appplication will be designed with a set of forms/pages with menus
representing choice of activities to be performed. Following are the functionalities of the Web application:

### 1. Homepage

It will display an attractive visual and menus for
various operations, including basic functionality such as Registration
and Login. After users are logged in, they will be able to access user's specific menus. For example, menus displayed to students will be
different from those displayed to teachers.

### 2. Register

It will allow new users to register on the Web application.
Users can be one of three types: Students, Teachers, or
Parent/Guardian. Registration will begin with selection of new user
name and password using which in future they will log in to the Web application. Registration details can include existing
email id, full name, address, age (in case of student), and so on.

Appropriate error-checking must be done on the fields of the form to
ensure correct data. For example, email id can be checked to see if it
is of appropriate format. (Hint: Use client-side validation).

Upon successful registration, an email should be sent to the user
welcoming the user to the application.

### 3. Login

It will allow successfully registered users to get logged in
to the Web application and access its various features.
After a user has logged in, the username should be displayed at
the top right corner.

### 4. Sign Out

Using this, logged in users can log out from the Web
application.

### 5. Feedback and Contact Us

These menu options have common
functionality for all category of users regardless of whether they
are students, teachers, or parents/guardians.

Feedback menu option should enable users to provide their
feedback about this portal through a feedback form.

Contact Us menu option should enable users to contact the
creators of the portal. An email id can be displayed here for
contact information.

### 6. For Students

Marks that they have scored in internal tests conducted by
teachers will be displayed in a table. Academic Progress menu
option will display the gradual progress in various tests across
the year in the form of table data or graphical elements such as
progress bars. Study Resources menu option should display a
table containing links to external sites, Videos, and additional
textbooks. Revision Classes menu option should display
information pertaining to extra classes for revision purposes.

Date and time of these classes can be displayed here. Optionally,
there can also be options to receive these information through
email. Helplines will display list of phone numbers that students
can call in case they require general assistance.

In this project, all key data shown on Web pages such as the
marks, academic progress, revision class information, and so on
will come from relevant database tables and will not be
hardcoded.

### 7. For Teachers

Teachers can update marks that students have scored in
internal tests conducted. This can be done through a form.
These marks must be updated in the database tables and will
reflect on the Student page.

Academic Progress menu option will enable teachers to
update the gradual progress in various tests across the year.
The data for this can be accepted via a form. This data also
must be stored in database tables.

Add Study Resources menu option should enable teachers to
add links to external sites, and additional textbooks. Revision
Classes Updation option should accept date and times for
extra classes for revision purposes. All of these data will go
into database tables.

### 8. For Parents/Guardians

They can view marks and academic progress of their wards.
Helplines will display list of phone numbers that
parents/guardians can call in case they require general
assistance. Marks and other details of wards can also be sent
via email to parents when they click an option ‘Send me by
Email’.
