<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
	<xsl:template match="/">
		<xsl:for-each select="productdata/product">
			<xsl:sort select="price" data-type="number" order="descending"/>
			<li>
				<font face="verdana" color="blue">
					<b>
						<xsl:text>Product ID: </xsl:text>
					</b>
				</font>
				<font face="verdana" color="red">
					<xsl:value-of select="@proid"/>
				</font>
				<br/>
				<font face="verdana" color="blue">
					<b>
						<xsl:text>Product Name: </xsl:text>
					</b>
				</font>
				<font face="verdana" color="red">
					<xsl:value-of select ="productname"/>
				</font>
			</li>
		</xsl:for-each>
	</xsl:template>
</xsl:stylesheet>
