#region copyright
// // Copyright Information
// // ==============================
// // EFCore_Top_Ten - ConventionsContextModelSnapshot.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EFCore_Top_Ten.EF;

namespace EFCore_Top_Ten.EF.Migrations.Conventions
{
    [DbContext(typeof(ConventionsContext))]
    partial class ConventionsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCore_Top_Ten.EF.FirstExample", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("EFCore_Top_Ten.EF.RelatedClass", b =>
                {
                    b.Property<int>("RelatedClassId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Foo");

                    b.Property<int>("SampleEntityId");

                    b.HasKey("RelatedClassId");

                    b.ToTable("RelatedClass");
                });

            modelBuilder.Entity("EFCore_Top_Ten.EF.SampleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("RelatedClassId");

                    b.Property<int?>("RelatedClassId1");

                    b.HasKey("Id");

                    b.HasIndex("RelatedClassId1");

                    b.ToTable("Samples");
                });

            modelBuilder.Entity("EFCore_Top_Ten.EF.SampleEntity", b =>
                {
                    b.HasOne("EFCore_Top_Ten.EF.RelatedClass", "RelatedClass")
                        .WithMany()
                        .HasForeignKey("RelatedClassId1");
                });
        }
    }
}
