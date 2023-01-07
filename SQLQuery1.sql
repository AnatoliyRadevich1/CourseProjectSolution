CREATE TABLE fulltable (
						id INT NOT NULL PRIMARY KEY IDENTITY,
						username VARCHAR(30) NOT NULL,
						userpass VARCHAR(30) NOT NULL,
						user_social_network_VK_acceess VARCHAR (30),
						user_social_network_FB_acceess VARCHAR (30),
						user_social_network_TG_acceess VARCHAR (30),
						user_page_address VARCHAR(30) NOT NULL,
						user_name_of_review VARCHAR(30),
						user_group_of_review_for_films BIT,
						user_group_of_review_for_books BIT,
						user_group_of_review_for_games BIT,
						user_tag TEXT,
						user_review_text TEXT,
						user_icon_address VARCHAR(50),
						user_marks TINYINT,
						anyuser_rate TINYINT,
						average_rate DECIMAL(2,1),
						user_dark_theme BIT,
						user_language_selection VARCHAR(30) NOT NULL,
						user_is_blocked BIT,
						user_is_deleted BIT,
						user_pdf_file_address VARCHAR(50)
						);



INSERT INTO fulltable (username, userpass, user_social_network_VK_acceess, user_social_network_FB_acceess, user_social_network_TG_acceess)
VALUES
('Tom Sawyer', 'Tom Sawyer pass', 'vk.com/TS', 'facebook.com/TS', '@TS'),
('Bob Wald', 'Bob Wald pass', 'vk.com/BW', 'facebook.com/BW', '@BW'),
('John Snow', 'John Snow pass', 'vk.com/JS', 'facebook.com/JS', '@JS'),
('Kate Summer', 'Kate Summer pass', 'vk.com/KS', 'facebook.com/KS', '@KS'),
('Ann Gingerhair', 'Ann Gingerhair pass', 'vk.com/AG', 'facebook.com/AG', '@AG'),
('Alma Berg', 'Alma Berg pass', 'vk.com/AB', 'facebook.com/AB', '@AB')

GO
SELECT user_marks FROM fulltable
WHERE user_marks>=0 AND user_marks <=10;




