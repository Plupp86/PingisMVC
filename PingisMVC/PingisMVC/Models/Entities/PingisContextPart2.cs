﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PingisMVC.Models.Entities
{
    public partial class PingisContext : DbContext
    {
		public PingisContext(DbContextOptions<PingisContext> options) : base(options)
		{

		}
	}
}
