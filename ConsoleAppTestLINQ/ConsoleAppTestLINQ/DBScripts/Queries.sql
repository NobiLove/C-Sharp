use BikeStores;

SELECT * FROM production.products WHERE list_price BETWEEN 1000 AND 2000

SELECT pp.product_name,pc.category_name,pb.brand_name,pp.model_year,pp.list_price
FROM production.products pp 
JOIN production.categories pc ON pp.category_id = pc.category_id
JOIN production.brands pb ON pp.brand_id = pb.brand_id
ORDER BY category_name,brand_name,model_year,list_price

SELECT pb.brand_name,SUM(pp.list_price) total
FROM production.products pp 
JOIN production.categories pc ON pp.category_id = pc.category_id
JOIN production.brands pb ON pp.brand_id = pb.brand_id
WHERE pp.model_year >= 2018
GROUP BY brand_name

SELECT * FROM (SELECT pp.product_name,pc.category_name,pb.brand_name,pp.model_year,pp.list_price
FROM production.products pp 
JOIN production.categories pc ON pp.category_id = pc.category_id
JOIN production.brands pb ON pp.brand_id = pb.brand_id
WHERE category_name LIKE '%mountain%') AS products
WHERE brand_name LIKE 'surly'
