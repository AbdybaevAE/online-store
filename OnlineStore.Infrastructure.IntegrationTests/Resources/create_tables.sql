CREATE TABLE categories (
    category_id uuid DEFAULT gen_random_uuid() primary key,
    category_name VARCHAR NOT NULL,
    category_description VARCHAR NOT NULL,
    category_parent_id uuid,
    foreign key(category_id) references categories(category_id)
);