Feature: PagePagination

Background: 
	Given a user searches for book on the search box

Scenario: Catalog Page pagination list number behavior
	And number 2 is shown on the pagination list
	When a user clicks number 2 on the pagination list
	Then page number 2 is loaded succesfully
	#This is how a test scenario should be written. Consice, understanble and easy to read for business/analysts and other readers.


Scenario: Clicking through pages until page 4 then click Next, Previous and ... 
	And number 2 is shown on the pagination list 
	When a user clicks number 2 on the pagination list
	And page number 2 is loaded succesfully
	And a user clicks number 3 on the pagination list
	And page number 3 is loaded succesfully
	And a user clicks number 4 on the pagination list
	And page number 4 is loaded succesfully
	And user clicks Next
	And user clicks Prev
	And clicks the three dots for next
	And clicks the last page
	And a user clicks number 1 on the pagination list

	

