Feature: ShopingCartCechkValues

#Scenario: Verify the price of the product and total cart price
	#Given a user navigates to a product
	#When the user adds the product to the shopping cart
	#Then the total price 

#following Test Case 2 steps

Scenario: Shopping cart check values
	Given a user clicks Alle Kategorien
	And clicks Alle Kategorien link
	And clicks on random category
	And clicks on random product
	And adds the product to the shopping card
	When the user opens the shopping cart
	Then the price of the product matches the price on the cart